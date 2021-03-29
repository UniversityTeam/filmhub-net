using System;
using System.Collections.Generic;
using System.Text;

namespace Filmhub.DB
{
	public class Film
	{
		public long id { get; set; }
		public string title { get; set; }
		public int year { get; set; }
		public double rating { get; set; }
		public int ratingcount { get; set; }
		public int views { get; set; }
		public string poster { get; set; }
		public long genre { get; set; }
		public bool membership { get; set; }
		public string url { get; set; }
		public Film(
			long id,
			string title,
			int year,
			double rating,
			int views,
			string poster,
			long genre,
			bool membership,
			string url,
			int ratingcount)
        {
			this.id = id;
			this.title = title;
			this.year = year;
			this.rating = rating;
			this.ratingcount = ratingcount;
			this.views = views;
			this.poster = poster;
			this.genre = genre;
			this.membership = membership;
			this.url = url;
		}
	}
}
