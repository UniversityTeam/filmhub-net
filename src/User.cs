using System;
using System.Collections.Generic;
using System.Text;

namespace Filmhub
{
    public class User : Guest
    {
        int session { get; set; }
        string login { get; set; }
        string hash { get; set; }

        public User(int id, int session, string login, string hash)
            : base(id)
        {
            this.session = session;
            this.login = login;
            this.hash = hash;
        }
    }
}
