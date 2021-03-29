using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System;
using System.IO;
using System.Linq;

namespace Filmhub.Http
{
    public class Client
    {
        public enum Status
        {
            Failed,
            Warning,
            Success
        }

        public Client(HttpListenerContext context)
        {
            Query = new Dictionary<string, string>();
            Request = context.Request;
            Response = context.Response;
            Ip = Request.UserHostAddress;
            Path = System.Uri.UnescapeDataString(Request.RawUrl);
            int offset = Path.IndexOf('?');
            if (offset > 0)
            {
                Path = Path.Substring(0, offset);
            }
            Method = Request.HttpMethod;
            UserAgent = Request.UserAgent;
            if(Request.HasEntityBody)
            {
                StreamReader reader = new StreamReader(Request.InputStream);
                string json = reader.ReadToEnd();
                Query = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, string>>(json);
            }

            foreach (var key in Request.QueryString.AllKeys)
            {
                Query.Add(key, Request.QueryString[key]);
            }

            CurrentStatus = Status.Success;
        }
        public string Ip { get; set; }
        public string Path { get; set; }
        public Status CurrentStatus { get; set; }
        public string StatusMsg { get; set; }
        public Dictionary<string, string> Query { get; set; }
        public string Method { get; set; }
        public bool Authorized { get; set; }
        public bool Moderator { get; set; }
        public bool Administrator { get; set; }
        public string UserAgent { get; set; }
        public HttpListenerRequest Request { get; set; }
        public HttpListenerResponse Response { get; set; }
        public string ExceptionMsg { get; set; }

        public override string ToString()
        {
            string query = "{";
            if(Query.Count != 0)
            {
                bool first = true;
                foreach(var key in Query.Keys)
                {
                    if(first)
                    {
                        first = false;
                    }
                    else
                    {
                        query += ", ";
                    }
                    query += $" {{\"{key}\": \"{Query[key]}\"}} ";
                }
            }
            query += "}";

            if (ExceptionMsg != null)
            {
                return $"[{Ip}]\t\t{Method}\t\t{Path}\t\t{StatusMsg}\t\t{query}\n{ExceptionMsg}";
            }
            else
            {
                return $"[{Ip}]\t\t{Method}\t\t{Path}\t\t{StatusMsg}\t\t{query}";
            }
        }
    }
}
