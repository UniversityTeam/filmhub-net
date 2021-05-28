using System;

namespace Filmhub
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program started...");

            User defaultUser = new User();
            User user1 = new User(2, 0, "user2", "6692c6d458ee6ad2951fbea3c65c8e779b18ec2ad5c8d611f693bb08842f72c1", true, false);
            User mainAdmin = new User(3, 0, "user4", "d7c908e405b358727174e6ff76b5ed277fc8e9f875c8d66c434c75ea8df296a7", true, true);

            mainAdmin.AddAdministrator(user1);


            Film firstFilm = new Film(1, "Bitcoin", 2017, 2.0f, 1050, 9000, "bitcoin.png", Genre.Triller, "ben", false);
            Film secondFilm = new Film(2, "Star wars 2", 2012, 4.5f, 4572, 15000, "star_wars.png", Genre.Detectives, "star_wars.mp4", true);
            Series firstSeries = new Series(3, "La casa de papel", 2017, 4.9f, 5000, 20000, "Arturito.tard", Genre.Triller, "allEP.mp4", false, 48);
            Comment firstComment = new Comment(0, 0, 1, "Bitcoin sucks", false);
            Comment secondComment = new Comment(0, 0, 1, "Or maybe not", true);
            Review firstReview = new Review(2, 3, 2, "Oh", true, false);

            Console.WriteLine("\n");
            Console.WriteLine("Lab5 started...");
            Console.WriteLine("\n");

            Console.WriteLine("Overrided methods");
            firstFilm.showInfo();
            firstSeries.showInfo();
            Console.WriteLine("\n");

            Console.WriteLine("Method from interface");
            firstSeries.display();
            Console.WriteLine("\n");

            Console.WriteLine("Upcasting...");
            Comment commentFromR = new Review(2, 1, 2, "Super", true, true);
            Console.WriteLine(commentFromR.GetType());
            Console.WriteLine("\n");

            Console.WriteLine("Downcasting...");
            Comment commD = (Comment)firstReview;
            Console.WriteLine(commD.GetType());
            Console.WriteLine("\n");


            Console.WriteLine("Lab5 doing by team №8 group IP-95: \nGuskov Danil, \nMaik Bohdan, \nOlyinik Yulia, \nPolishchuk Stepan.");
            Console.WriteLine("Lab5 ended...");
            Console.WriteLine("\n");
            Console.WriteLine("Press any key to close this window");
            Console.ReadLine();
        }
    }
}
