using System;
using System.Collections.Generic;
using System.Text;

namespace Filmhub
{
    public class Administrator : Moderator
    {
        public Administrator(int id, int session, string login)
           : base(id, session, login) { }
    }
}
