using System;
using System.Collections.Generic;
using System.Text;

namespace Filmhub.DB
{
    class Membership
    {
        public long Id { get; set; }
        public long Userid { get; set; }
        public string Expdate { get; set; }
        public Membership(long userid, string expdate)
        {
            Userid = userid;
            Expdate = expdate;
        }
    }
}
