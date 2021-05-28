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


            Film firstFilm = new Film(0, "Bitcoin", 2017, 0.0f, 1050, 9000, "bitcoin.png", Genre.Triller, "", false);
            Film secondFilm = new Film(1, "Star wars 2", 2012, 9.5f, 4572, 15000, "star_wars.png", Genre.Detectives, "star_wars.mp4", true);
            Comment firstComment = new Comment(0, 0, 1, "Bitcoin sucks", false);
            Comment secondComment = new Comment(0, 0, 1, "Or maybe not", true);

            Console.WriteLine("\n");
            Console.WriteLine("Lab4 started...");
            Console.WriteLine("\n");

            Console.WriteLine("Test binary overflow:");
            Console.WriteLine("First comment before +: " + firstComment.TextData);
            Console.WriteLine("Second comment before +: " + secondComment.TextData);
            Console.WriteLine($"New comment after adding first and second comments: {(firstComment + secondComment).TextData}");
            Console.WriteLine("\n");

            Console.WriteLine("Test comprasion overflow:");
            Console.WriteLine("First and second films had different genre and rating: " + (firstFilm != secondFilm));
            Console.WriteLine("First and second films had same genre and rating: " + (firstFilm == secondFilm));
            Console.WriteLine("\n");

            Console.WriteLine("Test unary overflow:");
            Console.WriteLine("First film views before ++: " + firstFilm.Views);
            ++firstFilm;
            Console.WriteLine("First film views after ++: " + firstFilm.Views);
            Console.WriteLine("Second film rating count before --: " + secondFilm.RatingCount);
            --secondFilm;
            Console.WriteLine("Second film rating count after --: " + secondFilm.RatingCount);
            Console.WriteLine("First comment status before ++: " + firstComment.Approved);
            ++firstComment;
            Console.WriteLine("First comment status after ++: " + firstComment.Approved);
            Console.WriteLine("First comment status before --: " + firstComment.Approved);
            --firstComment;
            Console.WriteLine("First comment status after --: " + firstComment.Approved);
            Console.WriteLine("\n");

            Console.WriteLine("Test logical overflow:");
            if (firstFilm) { 
                Console.WriteLine("First film is free."); 
            }
            else
            {
                Console.WriteLine("First film isn`t free.");
            }
            
            if (!firstFilm) { Console.WriteLine("First film has unvalid url."); }

            if (secondComment) { Console.WriteLine("Second comment is approved."); }

            if (user1) { Console.WriteLine("User1 has moderator or administrator access."); }


            Console.WriteLine("\n");

            Console.WriteLine("Lab4 doing by team №8 group IP-95: \nGuskov Danil, \nMaik Bohdan, \nOlyinik Yulia, \nPolishchuk Stepan.");
            Console.WriteLine("Lab4 ended...");
            Console.WriteLine("\n");
            Console.WriteLine("Press any key to close this window");
            Console.ReadLine();
        }
    }
}
