using System;
using System.Collections.Generic;
using System.Text;

namespace Filmhub
{
    public class Film : Show
    {
        public Film(int id, string title,
            int year, float rating,
            int rating_count, int views,
            string poster, Genre Genre,
            string url, bool free) : base(id, title, year, rating, rating_count, views, poster, Genre, url, free)
        {
            Id = id;
            Title = title;
            Year = year;
            Rating = rating;
            RatingCount = rating_count;
            Views = views;
            Poster = poster;
            genre = Genre;
            Url = url;
            Free = free;
        }

        public override void showInfo()
        {
            Console.WriteLine("Film showed!");
        }
    }
}
