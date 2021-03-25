using System;
using System.Collections.Generic;
using System.Text;

namespace Filmhub
{
    public class User
    {
        public int id { get; set; }
        public int session { get; set; }
        string login { get; set; }
        string hash { get; set; }
        public bool moderator { get; set; }
        public bool administrator { get; set; }

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
