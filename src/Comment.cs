using System;
using System.Collections.Generic;
using System.Text;

namespace Filmhub
{
    public class Comment
    {
        int id { get; set; }
        int filmid { get; set; }
        int userid { get; set; }

        string textdata { get; set; }
        bool approved { get; set; }

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
