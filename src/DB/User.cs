using System;
using System.Collections.Generic;
using System.Text;

namespace Filmhub.DB
{
    public class User
    {
        public long id { get; set; }
        public string login { get; set; }
        public string hash { get; set; }
        public int[] viewed { get; set; }

        public bool authorized { get; set; }
        public bool moderator { get; set; }
        public bool administrator { get; set; }

        public User(long id, string login, string hash, int[] viewed, bool authorized, bool moderator, bool administrator)
        {
            this.id = id;
            this.login = login;
            this.hash = hash;
            this.viewed = viewed;
            this.authorized = authorized;
            this.moderator = moderator;
            this.administrator = administrator;
        }
    }
}
