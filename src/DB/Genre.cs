using System;
using System.Collections.Generic;
using System.Text;

namespace Filmhub.DB
{
    public class Genre
    {
        public long Id { get; set; }
        public string Lable { get; set; }
        public Genre(long id, string lable)
        {
            Id = id;
            Lable = lable;
        }
    }
}
