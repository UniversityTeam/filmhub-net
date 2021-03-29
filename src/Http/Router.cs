using Filmhub.DB;
using Filmhub.Logging;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Linq;
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
            if (client.Query.ContainsKey("word"))
            {
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
        public void Filter(Client client, ref ILogger logger, ref Database db)
        {
            byte[] data;

            var keys = client.Query;
            var filmsSet = db.films.Where(
                film => film.genre == System.Convert.ToDecimal(keys["genre"])
            );


            if (keys.ContainsKey("year_to"))
            {
                if (keys["year_to"].Length != 0)
                {
                    var num = System.Convert.ToDecimal(keys["year_to"]);
                    if (num > 0)
                    {
                        filmsSet = filmsSet.Where(
                            film => film.year <= num
                        );
                    }
                }
            }
            if (keys.ContainsKey("year_from"))
            {
                if (keys["year_from"].Length != 0)
                {
                    var num = System.Convert.ToDecimal(keys["year_from"]);
                    if (num > 0)
                    {
                        filmsSet = filmsSet.Where(
                            film => film.year >= num
                        );
                    }
                }
            }

            string test2 = JsonSerializer.Serialize(filmsSet.ToList());

            if (keys["sort"] == "ALP_ASC")
            {
                filmsSet = (IOrderedQueryable<Film>)filmsSet.OrderBy(film => film.rating).Reverse();
            }
            else if (keys["sort"] == "ALP_DESC")
            {
                filmsSet = filmsSet.OrderBy(film => film.title);
            }
            else if (keys["sort"] == "YEAR_DESC")
            {
                filmsSet = filmsSet.OrderBy(film => film.year);
            }
            else if (keys["sort"] == "YEAR_ASC")
            {
                filmsSet = (IOrderedQueryable<Film>)filmsSet.OrderBy(film => film.year).Reverse();
            }
            else if (keys["sort"] == "VIEWS")
            {
                filmsSet = (IOrderedQueryable<Film>)filmsSet.OrderBy(film => film.views).Reverse();
            }

            string test3 = JsonSerializer.Serialize(filmsSet.ToList());

            data = System.Text.Encoding.UTF8.GetBytes(
                JsonSerializer.Serialize(filmsSet.ToList())
            );

            client.Response.OutputStream.Write(data, 0, data.Length);
            client.Response.StatusCode = 200;
            client.CurrentStatus = Client.Status.Success;
            client.StatusMsg = "200 OK";
        }
    }
}
