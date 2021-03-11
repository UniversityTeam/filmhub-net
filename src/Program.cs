using System;

namespace Filmhub
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creating database...");

            Database db = new Database();

            Console.WriteLine("Initilaing database...");

            db.AddUser(new User(0, 0, "user0", "e79e1ec22b533d8777ae3082a6f478311525521b46c1fdd38ac90df37f0b4a34"));
            db.AddUser(new User(1, 0, "user1", "46720a28913e48a4327c155775e4f023f1af473a6c0ea0cc2ce60650c639318e"));
            db.AddUser(new Moderator(2, 0, "user2", "6692c6d458ee6ad2951fbea3c65c8e779b18ec2ad5c8d611f693bb08842f72c1"));
            db.AddUser(new Administrator(3, 0, "user4", "d7c908e405b358727174e6ff76b5ed277fc8e9f875c8d66c434c75ea8df296a7"));

            db.AddFilm(new Film(0, "Bitcoin", 2017, 0.0f, 1050, 9000, "bitcoin.png", Genre.Triller, "bitcoin.mp4", true));
            db.AddFilm(new Film(1, "Star wars 2", 2012, 9.5f, 4572, 15000, "star_wars.png", Genre.Cyberpank, "star_wars.mp4", true));

            db.AddComment(new Comment(0, 0, 1, "Bitcoin sucks", true));

            Console.WriteLine("Database initialized");

            Console.WriteLine("Starting server...");

            Server server = new Server("static/");

            Console.WriteLine("Press any key to close this window");
            Console.ReadLine();
        }
    }
}
