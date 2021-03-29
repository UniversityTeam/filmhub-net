using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Filmhub.FS;
namespace Filmhub.DB
{
    class Database : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public Database()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Connect to PostgreSQL
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=password");

            // Init the DB

            // Create some users
            int[] arr1 = { 1, 0, 9, 24, 5, 16, 7 };
            Users.Add(new User(0, "user0", "e79e1ec22b533d8777ae3082a6f478311525521b46c1fdd38ac90df37f0b4a34", arr1));
            int[] arr2 = { 1, 6, 15, 5, 16, 7, 17, 18, 20 };
            Users.Add(new User(1, "user1", "46720a28913e48a4327c155775e4f023f1af473a6c0ea0cc2ce60650c639318e", arr2));
            int[] arr3 = { 19, 20, 22, 21, 13, 3, 14, 8, 9 };
            Users.Add(new User(1, "user2", "6692c6d458ee6ad2951fbea3c65c8e779b18ec2ad5c8d611f693bb08842f72c1", arr3));
            int[] arr4 = { 3, 2, 3, 7, 0, 1 };
            Users.Add(new User(1, "user4", "d7c908e405b358727174e6ff76b5ed277fc8e9f875c8d66c434c75ea8df296a7", arr4));

            Genres.Add(new Genre(0, "Природа"));
            Genres.Add(new Genre(1, "Урбан"));
            Genres.Add(new Genre(2, "КофиЁчек"));
            Genres.Add(new Genre(3, "Киберпанк"));
            Genres.Add(new Genre(4, "Design hud"));

            SaveChanges();

        }
    }
}
