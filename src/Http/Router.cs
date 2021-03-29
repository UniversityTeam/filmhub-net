using Filmhub.DB;
using Filmhub.Logging;
using System.Linq;
using System.Buffers;
using System.Text.Json;
using System.IO;
using System.IO.Pipes;
using System.Text.Json.Serialization;
namespace Filmhub.Http
{
    class Router
    {
        public void GetGenres(Client client, ref ILogger logger, ref Database db)
        {
            byte[] data = System.Text.Encoding.UTF8.GetBytes(JsonSerializer.Serialize(db.genres));
            client.Response.OutputStream.Write(data, 0, data.Length);
            client.Response.StatusCode = 200;
            client.CurrentStatus = Client.Status.Success;
            client.StatusMsg = "200 OK";
        }
    }
}
