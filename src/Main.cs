using System;
using Filmhub.Http;
using Filmhub.Logging;

namespace Filmhub
{
    class Program
    {
        static void Main(string[] args)
        {
            Hub hub = new Hub();
            hub.Start();
        }
    }
}
