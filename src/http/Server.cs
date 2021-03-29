using System;
using System.Collections.Generic;
using System.Collections.Specialized;

using System.Net;
using System.IO;

using Filmhub.FS;
using Filmhub.Logging;
using Filmhub.DB;

namespace Filmhub.Http
{
    public delegate void Callback(Client client, ILogger logger = null);

    class Server
    {
        private Cache staticCache;
        private Dictionary<string, Callback> routes;
        private Dictionary<Code, string> responses;
        private HttpListener listener;
        private string root;
        private ILogger logger;
        private Database db;

        public Server(string host, string root, ILogger logger, Database db)
        {
            this.db = db;
            this.logger = logger;
            this.root = root;
            listener = new HttpListener();
            responses = new Dictionary<Code, string>();
            routes = new Dictionary<string, Callback>();
            staticCache = new Cache();

            // Set up http server
            listener.Prefixes.Add(host);

            logger.Info($"Server created {host}");
        }
        ~Server()
        {
            logger.Info("Server stopped");
            listener.Stop();
        }

        public void AddRoute(string path, Callback callback)
        {
            routes.Add(path, callback);
        }
        public void SetStaticResponce(Code code, string path)
        {
            responses.Add(code, path);
        }

        // Process the new connection to the server
        // TODO: multithread
        private void Handle(Client client)
        {
            // Simple malicious filtration
            if (client.Path.Contains(".."))
            {
                return;
            }

            try
            {
                switch (client.Method)
                {
                    case "GET":
                        HandleStatic(client);
                        break;
                    case "POST":
                        HandleRoutes(client);
                        break;
                }
            }
            // Responce 500
            catch (Exception exception)
            {
                byte[] buffer = staticCache.Get($"{root}{responses[Code.INTERNAL_ERROR]}");
                client.Response.OutputStream.Write(buffer, 0, buffer.Length);
                client.Response.StatusCode = 500;
                client.Response.Close();
                client.CurrentStatus = Client.Status.Failed;
                client.StatusMsg = $"500 Internal error\n{exception}";
            }

            switch (client.CurrentStatus)
            {
                case Client.Status.Success:
                    logger.Info(client.ToString());
                    break;
                case Client.Status.Warning:
                    logger.Warning(client.ToString());
                    break;
                case Client.Status.Failed:
                    logger.Error(client.ToString());
                    break;
            }
        }

        private void HandleStatic(Client client)
        {
            // Set up default root file
            if (client.Path == "/")
            {
                client.Path = "/index.html";
            }

            string filePath = root + client.Path;

            // Response 404 if file doesn't exist
            if (!System.IO.File.Exists(filePath))
            {
                byte[] buffer404 = staticCache.Get($"{root}{responses[Code.NOT_FOUND]}");
                client.Response.OutputStream.Write(buffer404, 0, buffer404.Length);
                client.Response.StatusCode = 404;
                client.Response.Close();
                client.StatusMsg = "404 Not Found";
                client.CurrentStatus = Client.Status.Warning;
                return;
            }

            byte[] buffer = staticCache.Get(filePath);
            client.Response.OutputStream.Write(buffer, 0, buffer.Length);
            client.Response.StatusCode = 200;
            client.Response.Close();
            client.StatusMsg = "200 OK";
        }

        private void HandleRoutes(Client client)
        {
            Callback callback;

            if (routes.ContainsKey(client.Path))
            {
                callback = routes[client.Path];
                callback(client, logger);
                client.StatusMsg = "200 OK";
            }
            else
            // Responce 500
            {
                byte[] buffer = staticCache.Get($"{root}{responses[Code.INTERNAL_ERROR]}");
                client.Response.OutputStream.Write(buffer, 0, buffer.Length);
                client.Response.StatusCode = 500;
                client.Response.Close();
                client.StatusMsg = "500 Internal error";
                client.CurrentStatus = Client.Status.Warning;
            }
        }


        // Start listening for new connections
        public void Listen()
        {
            try
            {
                listener.Start();
            }
            catch (Exception exception)
            {
                logger.Error(exception.ToString());
                return;
            }

            logger.Info("Server started");

            while (listener.IsListening)
            {
                // Метод GetContext блокирует текущий поток, ожидая подключения
                Handle(new Client(listener.GetContext()));
            }
        }
    }
}