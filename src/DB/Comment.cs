using System;
using System.Collections.Generic;
using System.Text;

namespace Filmhub.DB
{
	class Comment
	{
		public long id { get; set; }
		public string data { get; set; }
		public bool approved { get; set; }
		public long film { get; set; }
		public long user { get; set; }
		public Comment(long id, long user, long film, string data, bool approved)
        {
			this.id = id;
			this.user = user;
			this.film = film;
			this.data = data;
			this.approved = approved;
		}
	}
}
