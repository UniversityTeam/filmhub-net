using Filmhub.DB;
using Filmhub.Logging;
using System.Buffers;
using System.Text.Json;
using System.IO;
using System;
using System.Linq;
using System.IO.Pipes;
using System.Text.Json.Serialization;
namespace Filmhub.Http
{
    class Router
    {
        public void GetGenres(Client client, ref ILogger logger, ref Database db)
        {
            byte[] data = System.Text.Encoding.UTF8.GetBytes(JsonSerializer.Serialize(db.genres.ToList()));
            client.Response.OutputStream.Write(data, 0, data.Length);
            client.Response.StatusCode = 200;
            client.CurrentStatus = Client.Status.Success;
            client.StatusMsg = "200 OK";
        }
        public void Catalog(Client client, ref ILogger logger, ref Database db)
        {
            byte[] data;

            // For search query
            if (client.Query.AllKeys.Contains("word"))
            {
                foreach(Film film in db.films)
                {
                    Console.WriteLine(film.title);
                }

                var films = db.films.Where(
                    film => film.title.Contains(client.Query["word"])
                    ).OrderBy(film => film.rating).ToList();
                data = System.Text.Encoding.UTF8.GetBytes(
                    JsonSerializer.Serialize(films)
                );
            }
            else
            {
                data = System.Text.Encoding.UTF8.GetBytes(JsonSerializer.Serialize(db.films.OrderBy(film => film.rating).ToList()));
            }

            client.Response.OutputStream.Write(data, 0, data.Length);
            client.Response.StatusCode = 200;
            client.CurrentStatus = Client.Status.Success;
            client.StatusMsg = "200 OK";
        }
        public void IsLogin(Client client, ref ILogger logger, ref Database db)
        {
            byte[] data;

            if (client.Authorized)
            {
                data = System.Text.Encoding.UTF8.GetBytes("true");
            }
            else
            {
                data = System.Text.Encoding.UTF8.GetBytes("false");
            }

            client.Response.OutputStream.Write(data, 0, data.Length);
            client.Response.StatusCode = 200;
            client.CurrentStatus = Client.Status.Success;
            client.StatusMsg = "200 OK";
        }
    }
}
