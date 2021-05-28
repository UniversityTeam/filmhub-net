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

        //Делегат
        delegate int Operation(int a);

        public void changeEPq(int a)
        {
            Operation changeQuantity = addEpisode;
            int newQuantity = changeQuantity(a);
            Console.WriteLine($"Now series has {newQuantity} episodes.");
        }
        private int addEpisode(int a)
        {
            episodes += a;
            return episodes;
        }
        //

        //Анонімний метод
        delegate void MessageHandler(string message);
        public void AnTest(string mes)
        {
            MessageHandler handler = delegate (string mes)
            {
                Console.WriteLine(mes);
            };
            handler(mes);

        }
        //

        //Лямбда вираз
        delegate int TotalTime(int minutesPerEP, int q);
        public void ShowTotalTime(int mpe)
        {
            TotalTime tt = (m, q) => m * q;
            int result = tt(mpe, episodes);
            Console.WriteLine($"U need spend {result} minutes for full series {Title}.");
        }
    }
}
