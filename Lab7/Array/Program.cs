using System;

namespace Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstArr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] secondArr = { -1, 0, 1, 2, 3, 4, 5 };

            Console.WriteLine($"First array : {firstArr}");
            Console.WriteLine($"Second array : {secondArr}");
            Console.WriteLine("\n");

            try
            {
                Console.WriteLine(firstArr[22]);
            }
            catch (Exception e)
            {
                Console.WriteLine("Array error:");
                Console.WriteLine(e.Message);
                Console.WriteLine("\n");
            }

            try
            {
                try
                {
                    throw new Exception("Inner catch!");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                for (int i = 0; i < firstArr.Length; i++)
                {
                    for (int j = 0; j < secondArr.Length; j++)
                    {
                        Console.WriteLine($"Div result: {firstArr[i] / secondArr[j]}");
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("\n");
        }
    }
}
