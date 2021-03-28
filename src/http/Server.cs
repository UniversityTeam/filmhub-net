using System;
using System.Collections.Generic;
using System.Collections.Specialized;

using System.Net;
using System.IO;

using Filmhub.FS;

namespace Filmhub
{
    namespace Http
    {
        public delegate void Callback(NameValueCollection request, Stream response);

        class Server
        {
            private Cache staticCache;
            private Dictionary<string, Callback> endpoints;
            private Dictionary<Code, string> responses;
            private HttpListener listener;
            private string root;

            public Server(string host, string root)
            {
                this.root = root;
                listener = new HttpListener();
                responses = new Dictionary<Code, string>();
                //endpoints = Dictionary<string, Callback>();
                staticCache = new Cache();

                // Set up http server
                listener.Prefixes.Add(host);
            }
            ~Server()
            {
                listener.Stop();
            }

            public void AddEndpoint(string path, Callback callback)
            {
                endpoints.Add(path, callback);
            }
            public void SetStaticResponce(Code code, string path)
            {
                responses.Add(code, path);
            }

            // Process the new connection to the server
            // TODO: multithread
            private void Handle(HttpListenerContext context)
            {
                HttpListenerRequest request = context.Request;

                string url = request.Url.MakeRelativeUri(request.Url).ToString();

                // Simple malicious filtration
                if (url.Contains(".."))
                {
                    return;
                }

                switch (request.HttpMethod)
                {
                    case "GET":
                        HandleStatic(url, context.Response.OutputStream);
                        return;
                    case "POST":
                        HandleEndpoints(url, request.QueryString, context.Response.OutputStream);
                        return;
                }
            }

            private void HandleStatic(string path, Stream response)
            {
                try
                {
                    if(path.Length == 0)
                    {
                        path = "/index.html";
                    }

                    byte[] buffer = staticCache.Get($"{root}{path}");
                    response.Write(buffer, 0, buffer.Length);
                    response.Close();
                }
                // Responce 404
                catch (Exception exception)
                {
                    byte[] buffer = staticCache.Get(responses[Code.NOT_FOUND]);
                    response.Write(buffer, 0, buffer.Length);
                    response.Close();
                    Console.WriteLine($"Responce 404: {exception}");
                }
            }

            private void HandleEndpoints(string path, NameValueCollection request, Stream response)
            {
                Callback callback;

                try
                {
                    callback = endpoints[path];
                    callback(request, response);
                }
                // Responce 500
                catch (Exception exception)
                {
                    byte[] buffer = staticCache.Get(responses[Code.NOT_FOUND]);
                    response.Write(buffer, 0, buffer.Length);
                    response.Close();
                    Console.WriteLine($"Responce 500: {exception}");
                }
            }

            // Start listening for new connections
            public void Listen()
            {
                listener.Start();
                while (listener.IsListening)
                {
                    // Метод GetContext блокирует текущий поток, ожидая подключения
                    Handle(listener.GetContext());
                }
            }
        }
    }
}
