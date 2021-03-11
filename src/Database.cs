using System;
using System.Collections.Generic;
using System.Text;

namespace Filmhub
{
    public class Database
    {
        List<User> users = new List<User>();
        List<Comment> comment = new List<Comment>();
        List<Film> films = new List<Film>();
        List<Guest> guests = new List<Guest>();

        public void AddUser(User value)
        {
            users.Add(value);
        }
        public void AddComment(Comment value)
        {
            comment.Add(value);
        }
        public void AddFilm(Film value)
        {
            films.Add(value);
        }
        public void AddGuest(Guest value)
        {
            guests.Add(value);
        }

        public void DelUser(User value)
        {
            users.Remove(value);
        }
        public void DelComment(Comment value)
        {
            comment.Remove(value);
        }
        public void DelFilm(Film value)
        {
            films.Remove(value);
        }
        public void DelGuest(Guest value)
        {
            guests.Remove(value);
        }

        public Database()
        {
            Console.WriteLine("Database created");
        }
    }
}
