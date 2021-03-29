using System;
using System.Collections.Generic;
using System.Text;

namespace Filmhub.DB
{
    class Membership
    {
        public long id { get; set; }
        public long userid { get; set; }
        public string expdate { get; set; }
        public Membership(long userid, string expdate)
        {
            this.userid = userid;
            this.expdate = expdate;
        }
    }
}
