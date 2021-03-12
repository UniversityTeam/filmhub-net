using System;
using System.Collections.Generic;
using System.Text;

namespace Filmhub
{
    public class Comment
    {
        public int id { get; set; }
        public int filmid { get; set; }
        public int userid { get; set; }

        public string textdata { get; set; }
        public bool approved { get; set; }

        public Comment(
            int id, 
            int filmid, 
            int userid, 
            string textdata, 
            bool approved
        ) {
            this.id = id;
            this.filmid = filmid;
            this.userid = userid;
            this.textdata = textdata;
            this.approved = approved;
        }
    }
}
