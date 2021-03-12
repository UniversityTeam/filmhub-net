using System;
using System.Collections.Generic;
using System.Text;

namespace Filmhub
{
    public class User
    {
        int id { get; set; }
        int session { get; set; }
        string login { get; set; }
        string hash { get; set; }
        bool moderator { get; set; }
        bool administrator { get; set; }

        public User(int id, int session, string login, string hash, bool moderator, bool administrator)
        {
            this.id = id;
            this.session = session;
            this.login = login;
            this.hash = hash;
            this.moderator = moderator;
            this.administrator = administrator;
        }
        public void AddFilm() { }
        public void RemoveFilm() { }
        public void LeaveComment() { }
        public void RateFilm() { }
        public void AddModerator() { }
        public void AddAdministrator() { }
        public void RemoveComment() { }
        public void RemoveUser() { }
        public void ShowRecommendations() { }

    }
}
