using System;
using System.Collections.Generic;
using System.Text;

namespace Filmhub
{
    public class Series : Show, ISeries
    {

        private int episodes;
        public int Episodes
        {
            get { return episodes; }
            set
            {
                if (value > 3)
                {
                    episodes = value;
                }
                else
                {
                    Console.WriteLine("Series should have more than 3 episodes!");
                }
            }
        }

        public void display()
        {
            Console.WriteLine("Series displayed!");
        }


        public Series(int id, string title,
            int year, float rating,
            int rating_count, int views,
            string poster, Genre Genre,
            string url, bool free, int episodesQ) : base(id, title, year, rating, rating_count, views, poster, Genre, url, free)
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
            episodes = episodesQ;
        }

        public override void showInfo()
        {
            Console.WriteLine("Series showed!");
        }

    }
}
