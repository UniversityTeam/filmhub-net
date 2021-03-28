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
        public delegate void Callback(NameValueCollection request, HttpListenerResponse response);

        class Server
        {
            private Cache staticCache;
            private Dictionary<string, Callback> routes;
            private Dictionary<Code, string> responses;
            private HttpListener listener;
            private string root;

            public Server(string host, string root)
            {
                this.root = root;
                listener = new HttpListener();
                responses = new Dictionary<Code, string>();
                routes = new Dictionary<string, Callback>();
                staticCache = new Cache();

                // Set up http server
                listener.Prefixes.Add(host);

                Console.WriteLine($"Server created {host}");
            }
            ~Server()
            {
                Console.WriteLine("Server stopped");
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
            private void Handle(HttpListenerContext context)
            {
                HttpListenerRequest request = context.Request;
                HttpListenerResponse response = context.Response;

                // TODO: store ip & user agent
                //string userAgent = request.UserAgent;
                string ip = request.UserHostAddress;
                string url = request.RawUrl;
                string method = request.HttpMethod;
                NameValueCollection query = request.QueryString;

                // Simple malicious filtration
                if (url.Contains(".."))
                {
                    return;
                }

                string result = "";

                try
                {
                    switch (method)
                    {
                        case "GET":
                            HandleStatic(ref url, response, ref result);
                            break;
                        case "POST":
                            HandleRoutes(ref url, request.QueryString, response, ref result);
                            break;
                    }

                }
                // Responce 500
                catch (Exception exception)
                {
                    byte[] buffer = staticCache.Get($"{root}{responses[Code.INTERNAL_ERROR]}");
                    response.OutputStream.Write(buffer, 0, buffer.Length);
                    response.StatusCode = 500;
                    response.Close();
                    result = $"500 Internal error\n{exception}";
                }

                if (query.Count == 0)
                {
                    Console.WriteLine($"[{ip}]\t\t{method}\t\t{url}\t\t{result}");
                }
                else
                {
                    string queryStr = query.ToString();
                    //queryStr = queryStr.Substring(13, queryStr.Length - 13);
                    Console.WriteLine($"[{ip}]\t\t{method}\t\t{url}\t\t{result}\t\t{queryStr}");
                }
            }

            private void HandleStatic(ref string path, HttpListenerResponse response, ref string result)
            {
                // Set up default root file
                if (path == "/")
                {
                    path = "index.html";
                }

                string filePath = $"{root}{path}";

                // Responce 404 if file doesn't exist
                if (!System.IO.File.Exists(filePath))
                {
                    byte[] buffer404 = staticCache.Get($"{root}{responses[Code.NOT_FOUND]}");
                    response.OutputStream.Write(buffer404, 0, buffer404.Length);
                    response.StatusCode = 404;
                    response.Close();
                    result = "404 Not Found";
                    return;
                }

                byte[] buffer = staticCache.Get(filePath);
                response.OutputStream.Write(buffer, 0, buffer.Length);
                response.StatusCode = 200;
                response.Close();
                result = "200 OK";
            }

            private void HandleRoutes(ref string path, NameValueCollection request, HttpListenerResponse response, ref string result)
            {
                Callback callback;

                if (routes.ContainsKey(path))
                {
                    callback = routes[path];
                    callback(request, response);
                    result = "200 OK";
                }
                else
                // Responce 500
                {
                    byte[] buffer = staticCache.Get($"{root}{responses[Code.NOT_FOUND]}");
                    response.OutputStream.Write(buffer, 0, buffer.Length);
                    response.StatusCode = 500;
                    response.Close();
                    result = "500 Internal error";
                }
            }
        

            // Start listening for new connections
            public void Listen()
            {
                try
                {
                    listener.Start();
                }
                catch(Exception exception)
                {
                    Console.WriteLine(exception);
                    return;
                }

                Console.WriteLine("Server started");

                while (listener.IsListening)
                {
                    // Метод GetContext блокирует текущий поток, ожидая подключения
                    Handle(listener.GetContext());
                }
            }
        }
    }
}
