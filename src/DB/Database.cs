using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Filmhub.Logging;
namespace Filmhub.DB
{
    public class Database : DbContext
    {
        public DbSet<User> users { get; set; }
        public DbSet<Genre> genres { get; set; }
        public DbSet<Comment> comments { get; set; }
        public DbSet<Membership> memberships { get; set; }
        public DbSet<Film> films { get; set; }
        ILogger logger;
        public Database(ILogger logger)
        {
            this.logger = logger;
            logger.Info("Creating database");
            try
            {
                Database.EnsureCreated();
            }
            catch(Exception exception)
            {
                logger.Error(exception.ToString());
            }
        }

        // Configuring handled in base class constructor
       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Connect to PostgreSQL
            logger.Info("Open database");
            try
            { 
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=admin");
            }
            catch (Exception exception)
            {
                logger.Error(exception.ToString());
            }
        }

        // Init the DB
        public void Init()
        {
            logger.Info("Initializing database");
            // Create some users
            int[] arr0 = { };
            int[] arr1 = { 1, 0, 9, 24, 5, 16, 7 };
            users.Add(new User(9, "user0", "e79e1ec22b533d8777ae3082a6f478311525521b46c1fdd38ac90df37f0b4a34", arr1, true, false, false));
            int[] arr2 = { 2, 6, 15, 5, 16, 7, 17, 18, 20 };
            users.Add(new User(1, "user1", "46720a28913e48a4327c155775e4f023f1af473a6c0ea0cc2ce60650c639318e", arr2, true, false, false));
            int[] arr3 = { 19, 20, 22, 21, 13, 3, 14, 8, 9 };
            users.Add(new User(2, "user2", "6692c6d458ee6ad2951fbea3c65c8e779b18ec2ad5c8d611f693bb08842f72c1", arr3, true, false, false));
            int[] arr4 = { 3, 2, 3, 7, 0, 1 };
            users.Add(new User(3, "user4", "d7c908e405b358727174e6ff76b5ed277fc8e9f875c8d66c434c75ea8df296a7", arr4, true, false, false));

            // Create admins & moders
            users.Add(new User(4, "adminDanya", "bad29384fb621dc842dd35ce274fa5fe523b711470b92b701d6cb02f29b3a603", arr0, true, true, true));
            users.Add(new User(5, "adminYulya", "01039d8eecaa8a9c1b7cee263f9eead78dea7827e4e3cd3cd6526877ce056de1", arr0, true, true, true));
            users.Add(new User(6, "adminStepa", "e269d1caa088c1f470c7fc4a09662078af2d7e9df488b78290825af924067f88", arr0, true, true, true));
            users.Add(new User(7, "adminBodya", "aa748722c846145eff66aa52cc36889497b2b958e18e3dd12891a1bef5d3b535", arr0, true, true, true));
            users.Add(new User(8, "moderka", "a9a0f658ae77e98c65dd0720663eab0b6696abf3c1bc4f1a43a6bb7aefa7484c", arr0, true, true, false));

            // Add genres
            genres.Add(new Genre(1, "Урбан"));
            genres.Add(new Genre(2, "КофиЁчек"));
            genres.Add(new Genre(3, "Киберпанк"));
            genres.Add(new Genre(4, "Design hud"));
            genres.Add(new Genre(5, "Природа"));

            // Add some comments
            comments.Add(new Comment(1, 4, 2, "Film so bad don`t rec", false));
            comments.Add(new Comment(2, 15, 3, "Noice", true));
            comments.Add(new Comment(3, 10, 2, "Good", false));
            comments.Add(new Comment(4, 4, 1, "Bad", false));
            comments.Add(new Comment(5, 1, 3, "Nice film about tables", false));
            comments.Add(new Comment(6, 1, 3, "Есть кто-то с снг?", false));
            comments.Add(new Comment(7, 1, 4, "Ugandas power!!!!", false));
            comments.Add(new Comment(8, 15, 3, "11/10, админ хороший человек", true));
           
            // Add films
            films.Add(new Film(28, "Bitcoin", 2017, 5.45, 300469, "Bitcoin.png", 4, true, "Bitcoin.mp4", 235600));
            films.Add(new Film(1, "Bridge", 2015, 7.25, 76489, "Bridge.png", 2, true, "Bridge.mp4", 27457));
            films.Add(new Film(2, "Buildings", 2002, 8.90, 103538, "Buildings.png", 2, true, "Buildings.mp4", 2657));
            films.Add(new Film(3, "Car", 2020, 9.56, 3235900, "Car.png", 4, false, "Car.mp4", 934613));
            films.Add(new Film(4, "Cherry", 2011, 8.98, 7853234, "Cherry.png", 2, false, "Cherry.mp4", 978900));
            films.Add(new Film(5, "City", 2004, 5.02, 4520683, "City.png", 2, true, "City.mp4", 90064));
            films.Add(new Film(6, "Coffee", 2020, 9.99, 7099098, "Coffee.png", 3, true, "Coffee.mp4", 390342));
            films.Add(new Film(7, "Computer", 1998, 3.67, 367833, "Computer.png", 5, true, "Computer.mp4", 237309));
            films.Add(new Film(8, "Design", 2004, 4.39, 46368008, "Design.png", 5, true, "Design.mp4", 562457));
            films.Add(new Film(9, "Dubai", 2015, 8.77, 52453, "Dubai.png", 2, true, "Dubai.mp4", 6796));
            films.Add(new Film(10, "Fire", 2012, 4.91, 34687900, "Fire.png", 1, true, "Fire.mp4", 7895));
            films.Add(new Film(11, "Futuristic", 2013, 6.72, 12319056, "Futuristic.png", 4, true, "Futuristic.mp4", 5678));
            films.Add(new Film(12, "Glitch", 2020, 7.68, 7099098, "Glitch.png", 5, false, "Glitch.mp4", 2457));
            films.Add(new Film(13, "Hud", 2015, 5.48, 5063452, "Hud.png", 5, true, "Hud.mp4", 624579));
            films.Add(new Film(14, "Jellyfish", 2001, 4.7, 340657, "Jellyfish.png", 1, true, "Jellyfish.mp4", 24576));
            films.Add(new Film(15, "Landing", 2018, 7.8, 530034, "Landing.png", 2, true, "Landing.mp4", 65796));
            films.Add(new Film(16, "Loading", 2010, 8.6, 102405, "Loading.png", 5, true, "Loading.mp4", 46797));
            films.Add(new Film(17, "Music", 2002, 9.5, 7099098, "Music.png", 4, true, "Music.mp4", 26089));
            films.Add(new Film(18, "Nebula", 2020, 6.65, 808540, "Nebula.png", 1, true, "Nebula.mp4", 80769));
            films.Add(new Film(19, "Neon", 2018, 8.5, 39704210, "Neon.png", 4, true, "Neon.mp4", 59008));
            films.Add(new Film(20, "Network", 2020, 5.95, 481024, "Network.png", 5, true, "Network.mp4", 80090));
            films.Add(new Film(21, "Ocean", 2020, 8.84, 1080040, "Ocean.png", 1, true, "Ocean.mp4", 3242308));
            films.Add(new Film(22, "Palm Trees", 2019, 9.42, 1430078, "Palm Trees.png", 1, true, "Palm Trees.mp4", 97867));
            films.Add(new Film(23, "Seoul", 2017, 7.9, 802379, "Seoul.png", 2, true, "Seoul.mp4", 46478));
            films.Add(new Film(24, "Sparrow", 2016, 5.16, 6095601, "Sparrow.png", 1, true, "Sparrow.mp4", 23444));
            films.Add(new Film(25, "Trees", 2016, 4.34, 5006062, "Trees.png", 1, true, "Trees.mp4", 42356));
            films.Add(new Film(26, "Wireframe", 2016, 8.43, 4290063, "Wireframe.png", 4, true, "Wireframe.mp4", 59098));
            films.Add(new Film(27, "World", 2017, 9.31, 10450090, "World.png", 1, true, "World.mp4", 7642311));

            try
            {
                // Commit changes
                SaveChanges();
            }
            catch (Exception) { }
        }
    }
}
