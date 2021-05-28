using System;
using System.Collections.Generic;
using System.Text;

namespace Filmhub
{
    public class Film
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
                if (value.Length >= 14 && value.Length <= 250)
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


        //Перевантаження унарних операторів
        public static Film operator ++(Film film)
        {
            film.views++;
            return film;
        }

        public static Film operator --(Film film)
        {
            film.rating_count--;
            return film;
        }


        //Перевантаження операторів порівняння
        public static bool operator ==(Film firstFilm, Film secondFilm)
        {
            if (firstFilm.genre != secondFilm.genre)
            {
                return false;
            }

            return firstFilm.rating == secondFilm.rating;
        }

        public static bool operator !=(Film firstFilm, Film secondFilm)
        {
            return !(firstFilm.rating == secondFilm.rating && firstFilm.genre == secondFilm.genre);
        }


        //Перевантаження логічних операторів
        public static bool operator true(Film film)
        {
            return film.free;
        }

        public static bool operator false(Film film)
        {
            return !film.free;
        }

        public static bool operator !(Film film)
        {
            return string.IsNullOrEmpty(film.url);
        }


    }
}
