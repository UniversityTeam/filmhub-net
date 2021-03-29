using System;
using System.Collections.Generic;
using System.Text;

namespace Filmhub.Logging
{
    public abstract class ILogger
    {
        public abstract void Info(string data);
        public abstract void Warning(string data);
        public abstract void Error(string data);
    }
}
