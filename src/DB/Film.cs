using System;
using System.Collections.Generic;
using System.Text;

namespace Filmhub.DB
{
	class Film
	{
		public long Id { get; set; }
		public string Title { get; set; }
		public int Year { get; set; }
		public double Rating { get; set; }
		public int Ratingcount { get; set; }
		public int Views { get; set; }
		public string Poster { get; set; }
		public long Genre { get; set; }
		public bool Membership { get; set; }
		public string Url { get; set; }
		public Film(
			long id,
			string title,
			int year,
			double rating,
			int views,
			string url,
			long genre,
			bool membership,
			string poster,
			int ratingcount)
        {
			Id = id;
			Title = title;
			Year = year;
			Rating = rating;
			Ratingcount = ratingcount;
			Views = views;
			Poster = poster;
			Genre = genre;
			Membership = membership;
			Url = url;
		}
	}
}
