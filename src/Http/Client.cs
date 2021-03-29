using System.Collections.Specialized;
using System.Net;

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
            Request = context.Request;
            Response = context.Response;
            Ip = Request.UserHostAddress;
            Path = Request.RawUrl;
            Method = Request.HttpMethod;
            UserAgent = Request.UserAgent;
            Query = Request.QueryString;
            CurrentStatus = Status.Success;
        }
        public string Ip { get; set; }
        public string Path { get; set; }
        public Status CurrentStatus { get; set; }
        public string StatusMsg { get; set; }
        public NameValueCollection Query { get; set; }
        public string Method { get; set; }
        public int Session { get; set; }
        public string UserAgent { get; set; }
        public HttpListenerRequest Request { get; set; }
        public HttpListenerResponse Response { get; set; }

        public override string ToString()
        {
            if (Query.Count == 0)
            {
                return $"[{Ip}]\t\t{Method}\t\t{Path}\t\t{StatusMsg}";
            }
            else
            {
                string queryStr = Query.ToString();
                //queryStr = queryStr.Substring(13, queryStr.Length - 13);
                return $"[{Ip}]\t\t{Method}\t\t{Path}\t\t{StatusMsg}\t\t{queryStr}";
            }
        }
    }
}
