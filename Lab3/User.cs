using System;
using System.Collections.Generic;
using System.Text;

namespace Filmhub
{
    public class User
    {
        private int id;
        private int session;
        private string login;
        private string hash;
        private bool moderator;
        private bool administrator;

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
                    Console.WriteLine("User id must be positive number!");
                }
            }
        }
        public int Session
        {
            get { return session; }
            set
            {
                if (session > 0)
                {
                    session = value;
                }
                else
                {
                    Console.WriteLine("Session must be positive number!");
                }
            }
        }
        public string Login
        {
            get { return login; }
            set
            {
                if (value.Length >= 6)
                {
                    login = value;
                }
                else
                {
                    Console.WriteLine("Login must be at least 6 characters!");
                }
            }
        }
        public string Hash
        {
            get { return hash; }
            set
            {
                if (value.Length >= 20)
                {
                    hash = value;
                }
                else
                {
                    Console.WriteLine("Hash must be at least 20 characters!");
                }
            }
        }
        public bool Moderator
        {
            get { return moderator; }
            set
            {
                moderator = value;
            }
        }
        public bool Administrator
        {
            get { return administrator; }
            set
            {
                administrator = value;
            }
        }

        public User(int id, int session, string login, string hash, bool moderator, bool administrator)
        {
            this.id = id;
            this.session = session;
            this.login = login;
            this.hash = hash;
            this.moderator = moderator;
            this.administrator = administrator;
            Console.WriteLine("Created new user with arguments.");
        }

        public User()
        {
            Console.WriteLine("Created new user without arguments.");
        }

        //Перевантаження логічних операторів
        public static bool operator true(User user)
        {
            return user.moderator || user.administrator;
        }

        public static bool operator false(User user)
        {
            return !(user.moderator || user.administrator);
        }

        public void AddFilm() { }
        public void RemoveFilm() { }
        public void LeaveComment() { }
        public void RateFilm() { }
        public void AddModerator() { }
        public void AddAdministrator(User user) 
        {
            if (this.administrator)
            {
                user.administrator = true;
                Console.WriteLine($"User with id = {user.id} now is Administrator!");
            }
        }
        public void RemoveComment() { }
        public void RemoveUser() { }
        public void ShowRecommendations() { }

    }
}
