using System;
using System.Collections.Generic;
using System.Text;

namespace Filmhub.Logging
{
    public class Logger : ILogger
    {
        ~Logger()
        {
            Console.ResetColor();
        }

        public override void Info(string data)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"[i]\t{data}");
        }
        public override void Warning(string data)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"[w]\t{data}");
        }
        public override void Error(string data)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"[e]\t{data}");
        }
    }
}
