using System;
using System.Threading;

namespace Lab8_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lab8 - Task: 4_1");
            Console.WriteLine("\n");
            Thread th1 = new Thread(new ParameterizedThreadStart(new Sum().getResult));
            Thread th2 = new Thread(new ParameterizedThreadStart(new Sum().getResult));
            Thread th3 = new Thread(new ParameterizedThreadStart(new Sum().getResult));
            th1.Start(1);
            th2.Start(2);
            th3.Start(3);
            Console.ReadKey();
        }
    };
    class Sum
    {

        public void getResult(object n)
        {
            int q = 100000000;
            int result = 0;
            var startT = DateTime.Now;
            for (int i = 1; i <= q; i++) { result += i; }
            var endT = DateTime.Now;
            var totalTime = (endT - startT);
            Console.WriteLine($"Thread: {n}.");
            Console.WriteLine($"Thread: {n}. Iteration time: {totalTime.TotalMilliseconds}. Result: {result}");
        }
    }
}

