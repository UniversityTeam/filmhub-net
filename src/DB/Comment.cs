using System;
using System.Collections.Generic;
using System.Text;

namespace Filmhub.DB
{
	class Comment
	{
		public long Id { get; set; }
		public long Filmid { get; set; }
		public long Userid { get; set; }
		public string Data { get; set; }
		public bool Approved { get; set; }
		public Comment(long id, long userid, long filmid, string data, bool approved)
        {
			Id = id;
			Userid = userid;
			Filmid = filmid;
			Data = data;
			Approved = approved;
        }
	}
}
