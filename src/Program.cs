using System;

namespace Filmhub
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lab1 started...");

            User defaultUser = new User(0, 0, "user0", "e79e1ec22b533d8777ae3082a6f478311525521b46c1fdd38ac90df37f0b4a34", false, false);
            User moderator = new User(2, 0, "user2", "6692c6d458ee6ad2951fbea3c65c8e779b18ec2ad5c8d611f693bb08842f72c1", true, false);
            User administrator = new User(3, 0, "user4", "d7c908e405b358727174e6ff76b5ed277fc8e9f875c8d66c434c75ea8df296a7", true, true);

            Film firstFilm = new Film(0, "Bitcoin", 2017, 0.0f, 1050, 9000, "bitcoin.png", Genre.Triller, "bitcoin.mp4", true);
            Film secondFilm = new Film(1, "Star wars 2", 2012, 9.5f, 4572, 15000, "star_wars.png", Genre.Cyberpank, "star_wars.mp4", true);

            Comment firstComment = new Comment(0, 0, 1, "Bitcoin sucks", true);

            Console.WriteLine("Lab1 doing by team №8 group IP-95: \nGuskov Danil, \nMaik Bohdan, \nOlyinik Yulia, \nPolishchuk Stepan.");

            Console.WriteLine("Lab1 ended...");

            Console.WriteLine("Press any key to close this window");
            Console.ReadLine();
        }
    }
}
