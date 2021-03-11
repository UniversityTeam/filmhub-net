using System;
using System.Collections.Generic;
using System.Text;

namespace Filmhub
{
    public class Moderator : User
    {
        public Moderator(int id, int session, string login)
           : base(id, session, login) {}
    }
}
