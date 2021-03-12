using System;
using System.Collections.Generic;
using System.Text;

namespace Filmhub
{
    public class Film
    {
        public int id;
        public string title;
        public int year;
        public float rating;
        public int rating_count;
        public int views;
        public string poster;
        public Genre genre;
        public string url;
        public bool free;

        public Film(
            int id,
            string title,
            int year,
            float rating,
            int rating_count,
            int views,
            string poster,
            Genre genre,
            string url,
            bool free
        ) {
            this.id = id;
            this.title = title;
            this.year = year;
            this.rating = rating;
            this.rating_count = rating_count;
            this.views = views;
            this.poster = poster;
            this.genre = genre;
            this.url = url;
            this.free = free;
        }
    }
}
