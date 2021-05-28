using System;
using System.IO;
using System.Threading;

namespace Lab8_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lab8 - Task: 4_4");
            Console.WriteLine("\n");
            fileWorker fw = new fileWorker("Test.txt");

            Thread th1 = new Thread(new ThreadStart(fw.WriteFile)) { Name = "1" };
            Thread th2 = new Thread(new ThreadStart(fw.WriteFile)) { Name = "2" };
            Thread th3 = new Thread(new ThreadStart(fw.WriteFile)) { Name = "3" };
            Thread th4 = new Thread(new ThreadStart(fw.WriteFile)) { Name = "4" };

            th1.Start();
            th2.Start();
            th3.Start();
            th4.Start();

            Console.ReadKey();
        }
    };
    class fileWorker
    {
        private string filePath;
        private string dirPath = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())));
        private Object locker = new Object();
        private Semaphore sObj = new Semaphore(2, 2);
        public fileWorker(string path)
        {
            filePath = $"{dirPath}\\{path}";
        }
        public void ReadFile()
        {
            lock (locker)
            {
                using (StreamReader file = new StreamReader(filePath))
                {
                    Console.WriteLine(file.ReadLine());
                }
            }
        }

        public void WriteFile()
        {
            string text = $"Thread {Thread.CurrentThread.Name}; ";
            lock (locker)
            {
                sObj.WaitOne();
                using (StreamWriter file = new StreamWriter(filePath, append: true))
                {
                    for (int i = 1; i < 4; i++)
                    {
                        file.WriteLine($"Line №{i}: {text}");
                    }
                }

                using (StreamReader file = new StreamReader(filePath))
                {
                    Console.WriteLine($"After thread №{Thread.CurrentThread.Name}");
                    Console.WriteLine("\n");
                    Console.WriteLine(file.ReadToEnd());
                    Console.WriteLine("--------------------------------");
                    Console.WriteLine("\n");
                }
                sObj.Release();
            }
        }
    }
}

