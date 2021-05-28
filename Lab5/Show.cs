using System;
using System.Collections.Generic;
using System.Text;

namespace Filmhub
{
    public abstract class Show
    {
        private int id;
        private string title;
        private int year;
        private float rating;
        private int rating_count;
        private int views;
        private string poster;
        private string url;
        private bool free;

        public int Id
        {
            get { return id; }
            set
            {
                if (value > 0)
                {
                    id = value;
                }
                else
                {
                    Console.WriteLine("Film id must be positive number!");
                }
            }
        }

        public string Title
        {
            get { return title; }
            set
            {
                if (value.Length > 1 && value.Length < 100)
                {
                    title = value;
                }
                else
                {
                    Console.WriteLine("Title is incorrect!");
                }
            }
        }

        public int Year
        {
            get { return year; }
            set
            {
                if (value >= 1895 && value < 2022)
                {
                    year = value;
                }
                else
                {
                    Console.WriteLine("Realease year is incorrect!");
                }
            }
        }

        public float Rating
        {
            get { return rating; }
            set
            {
                if (value >= 1 && value <= 5)
                {
                    rating = value;
                }
                else
                {
                    Console.WriteLine("Rate in diapason from 1 to 5!");
                }
            }
        }

        public int RatingCount
        {
            get { return rating_count; }
            set
            {
                if (value >= 0)
                {
                    rating_count = value;
                }
                else
                {
                    Console.WriteLine("Rating count is incorrect!");
                }
            }
        }

        public int Views
        {
            get { return views; }
            set
            {
                if (value >= 0)
                {
                    views = value;
                }
                else
                {
                    Console.WriteLine("Views count is incorrect!");
                }
            }
        }

        public string Poster
        {
            get { return poster; }
            set
            {
                if (value.Length > 4 && value.Length < 252)
                {
                    poster = value;
                }
                else
                {
                    Console.WriteLine("Poster name is incorrect!");
                }
            }
        }

        public string Url
        {
            get { return url; }
            set
            {
                if (value.Length >= 0 && value.Length <= 250)
                {
                    url = value;
                }
                else
                {
                    Console.WriteLine("Url is incorrect!");
                }
            }
        }

        public bool Free
        {
            get { return free; }
            set
            {
                free = value;
            }
        }

        public Genre genre { get; set; }


        //Перевантаження унарних операторів
        public static Show operator ++(Show show)
        {
            show.views++;
            return show;
        }

        public static Show operator --(Show show)
        {
            show.rating_count--;
            return show;
        }


        //Перевантаження операторів порівняння
        public static bool operator ==(Show firstFilm, Show secondFilm)
        {
            if (firstFilm.genre != secondFilm.genre)
            {
                return false;
            }

            return firstFilm.rating == secondFilm.rating;
        }

        public static bool operator !=(Show firstFilm, Show secondFilm)
        {
            return !(firstFilm.rating == secondFilm.rating && firstFilm.genre == secondFilm.genre);
        }


        //Перевантаження логічних операторів
        public static bool operator true(Show film)
        {
            return film.free;
        }

        public static bool operator false(Show film)
        {
            return !film.free;
        }

        public static bool operator !(Show film)
        {
            return string.IsNullOrEmpty(film.url);
        }

        public Show(int id, string title,
            int year, float rating,
            int rating_count, int views,
            string poster, Genre Genre,
            string url, bool free)
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

        public virtual void showInfo()
        {
            Console.WriteLine("Virtual showed!");
        }

    }
}
