using System;
using System.Collections.Generic;
using System.Text;

namespace Filmhub.Http
{
    struct Endpoint
    {
        public Method method { get; set; }
        public AsyncCallback callback { get; set; }

        public Endpoint(Method method, AsyncCallback callback)
        {
            this.method = method;
            this.callback = callback;
        }
    }
}
