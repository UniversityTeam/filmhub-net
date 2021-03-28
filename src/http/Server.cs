using System;
using System.Collections.Generic;
using System.Text;

using System.Net;
using System.IO;

namespace Filmhub
{
    namespace Http
    {
        class Server
        {
            private Dictionary<string, Endpoint> endpoints;
            private HttpListener listener;
            private string root;

            public Server(string host, string root)
            {
                this.root = root;
                listener = new HttpListener();

                // Set up http server
                listener.Prefixes.Add(host);
                listener.Start();
            }
            ~Server()
            {
                listener.Stop();
            }

            public void AddEndpoint(Method method, string path, AsyncCallback callback)
            {
                endpoints.Add(path, new Endpoint(method, callback));
            }

            // Process the new connection to the server
            // TODO: multithread
            private void Handle(HttpListenerContext context)
            {
                HttpListenerRequest request = context.Request;

                Console.WriteLine(request.Url.AbsoluteUri);
                Console.WriteLine(request.HttpMethod);

                // Simple malicious filtration
                if (request.Url.AbsoluteUri.Contains(".."))
                {
                    return;
                }

                Endpoint endpoint;

                try
                {
                    endpoint = endpoints[request.Url.AbsoluteUri];
                }
                catch(Exception exception)
                {

                    Console.WriteLine($"May some error occured: {exception}");
                    return;
                }

                switch (request.HttpMethod)
                {
                    case "GET":
                        break;
                    case "POST":
                        break;
                }

                // получаем объект ответа
                HttpListenerResponse response = context.Response;
                // создаем ответ в виде кода html
                string responseStr = "<html><head><meta charset='utf8'></head><body>404 Not Found</body></html>";
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseStr);
                // получаем поток ответа и пишем в него ответ
                response.ContentLength64 = buffer.Length;
                Stream output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);
                // закрываем поток
                output.Close();
                // останавливаем прослушивание подключений
            }

            // Start listening for new connections
            public void Listen()
            {
                while (listener.IsListening)
                {
                    // Метод GetContext блокирует текущий поток, ожидая подключения
                    Handle(listener.GetContext());
                }
            }



        }
    }
}
