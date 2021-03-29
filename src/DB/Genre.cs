using System;
using System.Collections.Generic;
using System.Text;

namespace Filmhub.DB
{
    public class Genre
    {
        public long id { get; set; }
        public string lable { get; set; }
        public Genre(long id, string lable)
        {
            this.id = id;
            this.lable = lable;
        }
    }
}
