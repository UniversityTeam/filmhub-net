using System;
using System.Collections.Generic;
using System.Text;

namespace Filmhub.DB
{
    class User
    {
        public long Id { get; set; }
        public string Login { get; set; }
        public string Hash { get; set; }
        public int[] Viewed { get; set; }

        public bool Authorized { get; set; }
        public bool Moderator { get; set; }
        public bool Administrator { get; set; }

        public User(long id, string login, string hash, int[] viewed, bool authorized, bool moderator, bool administrator)
        {
            Id = id;
            Login = login;
            Hash = hash;
            Viewed = viewed;
            Authorized = authorized;
            Moderator = moderator;
            Administrator = administrator;
        }
    }
}
