using System;
using System.Collections.Generic;
using System.Text;

namespace Filmhub
{
    public class Comment
    {
        //Делегат
        delegate void Status();
        public void showStatus()
        {
            Status stat;
            if (approved)
            {
                stat = isApproved;
            }
            else
            {
                stat = isntApproved;
            }
            stat();
        }

        private static void isApproved()
        {
            Console.WriteLine("Comment is approved!");
        }

        private static void isntApproved()
        {
            Console.WriteLine("Comment isn`t approved!");
        }
        //

        private int id;
        private int filmid;
        private int userid;
        private string textdata;
        private bool approved;

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
                    Console.WriteLine("Comment id must be positive number!");
                }
            }
        }
        public int FilmId
        {
            get { return filmid; }
            set
            {
                if (value > 0)
                {
                    filmid = value;
                }
                else
                {
                    Console.WriteLine("Film id must be positive number!");
                }
            }
        }
        public int UserId
        {
            get { return userid; }
            set
            {
                if (value > 0)
                {
                    userid = value;
                }
                else
                {
                    Console.WriteLine("User id must be positive number!");
                }
            }
        }
        public string TextData
        {
            get { return textdata; }
            set
            {
                if (value.Length > 3)
                {
                    textdata = value;
                }
                else
                {
                    Console.WriteLine("Comment is too short!");
                }
            }
        }
        public bool Approved
        {
            get { return approved; }
            set
            {
                approved = value;
            }
        }

        public Comment(
            int id, 
            int filmid, 
            int userid, 
            string textdata, 
            bool approved
        ) {
            this.id = id;
            this.filmid = filmid;
            this.userid = userid;
            this.textdata = textdata;
            this.approved = approved;
        }

        //Перевантаження бінарних операторів
        public static Comment operator +(Comment comment1, Comment comment2)
        {
            if (comment1.userid == comment2.userid && comment1.filmid == comment2.filmid)
            {
                string data = comment1.textdata + '\n' + comment2.textdata;
                bool apr = comment1.approved && comment2.approved;
                Comment unitedComment = new Comment(comment1.id, comment1.filmid, comment1.userid, data, apr); ;
                return unitedComment;
            }
            return comment1;
        }

        //Перевантаження унарних операторів
        public static Comment operator ++(Comment comment)
        {
            comment.approved = true;
            return comment;
        }

        public static Comment operator --(Comment comment)
        {
            comment.approved = false;
            return comment;
        }

        //Перевантаження логічних операторів
        public static bool operator true(Comment comment)
        {
            return comment.approved;
        }

        public static bool operator false(Comment comment)
        {
            return !comment.approved;
        }
    }

    public class Review : Comment
    {
        private bool recommended;

        public bool Recommended
        {
            get { return recommended; }
            set
            {
                recommended = value;
            }
        }

        public Review(
            int id,
            int filmid,
            int userid,
            string textdata,
            bool rec,
            bool approved
        ) : base(id, filmid, userid, textdata, approved)
        {
            Id = id;
            FilmId = filmid;
            UserId = userid;
            TextData = textdata;
            Approved = approved;
            recommended = rec;
        }
    }
}
