using System;
using System.Collections.Generic;
using System.Text;

namespace Filmhub
{
    class Server
    {
        List<Session> sessions;
        Dictionary<Session, User> users;

        string RootFolder;


        public Server(string RootFolder)
        {
            this.RootFolder = RootFolder;
            Console.WriteLine("Server started");
        }
    }
}
