using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MultiThreadedPrinting
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*****Synchronizing Threads *****\n");
            //Printer p = new Printer();
            //Thread[] threads = new Thread[10];
            //for (int i = 0; i < 10; i++)
            //{
            //    threads[i] = new Thread(new ThreadStart(p.PrintNumbers))
            //    {
            //        Name = $"Worker thread {i}"
            //    };
            //}
            //// Now start each thread.
            //foreach (Thread thread in threads)
            //{
            //    thread.Start();
            //}
            // Interlocked
            AddOne();
            SafeAssignment();
            CompareAndExchange();
            Console.ReadLine();
        }
        public static void AddOne()
        {
            int intVal = 0;
            int newVal = Interlocked.Increment(ref intVal);
            Console.WriteLine(intVal);
        }
        public static void SafeAssignment()
        {
            int myInt = 9;
            Interlocked.Exchange(ref myInt, 82);
            Console.WriteLine(myInt);
        }
        public static void CompareAndExchange()
        {
            // If the value of i is currently 83, change i to 99.
            int i = 83;
            Interlocked.CompareExchange(ref i, 99, 83);
            Console.WriteLine(i);
        }
    }
}
