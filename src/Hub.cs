using System;
using System.Collections.Generic;
using System.Text;
using Filmhub.Http;
using Filmhub.Logging;
using Filmhub.DB;

namespace Filmhub
{
    class Hub
    {
        private Logger logger;
        private Server server;
        private Database db;

        public Hub()
        {
            logger = new Logger();
            db = new Database(logger);
            db.Init();
            server = new Server("http://localhost:8000/", "http/static", logger, db);

            server.SetStaticResponce(Code.NOT_FOUND, "404.html");
            server.SetStaticResponce(Code.INTERNAL_ERROR, "500.html");

            Router router = new Router();
            server.AddRoute("/getgenres", router.GetGenres);
            server.AddRoute("/catalog", router.Catalog);
            server.AddRoute("/islogin", router.IsLogin);
        }

        public void Start()
        { 
            server.Listen();
        }
    }
}
