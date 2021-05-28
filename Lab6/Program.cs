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

            Console.WriteLine("Lab6 started...");
            Console.WriteLine("\n");

            Console.WriteLine("Delegates:");
            firstFilm.aboutFilm();
            secondComment.showStatus();
            Console.WriteLine($"Episodes in first series: {firstSeries.Episodes}");
            firstSeries.changeEPq(4);
            Console.WriteLine($"Episodes in first series: {firstSeries.Episodes}");
            Console.WriteLine("\n");

            Console.WriteLine("Event:");
            user1.Notify += DisplayMessage;
            user1.Administrator = true;
            user1.Administrator = false;
            user1.Administrator = true;
            user1.Moderator = false;
            Console.WriteLine("\n");

            Console.WriteLine("Annonymous methods:");
            firstFilm.AnTest("Annonymous method test for Film.");
            firstSeries.AnTest("Annonymous method test for Series.");
            Console.WriteLine("\n");

            Console.WriteLine("Lambda expression:");
            firstSeries.ShowTotalTime(24);
            Console.WriteLine("\n");

            Console.WriteLine("Lab6 doing by team №8 group IP-95: \nGuskov Danil, \nMaik Bohdan, \nOlyinik Yulia, \nPolishchuk Stepan.");
            Console.WriteLine("Lab6 ended...");
            Console.WriteLine("\n");
            Console.WriteLine("Press any key to close this window");
            Console.ReadLine();
        }

        // Обробник для події
        private static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
