using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace AddWithThreads
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Adding with Thread objects *****");
            Console.WriteLine("ID of thread in Main(): {0}",
            Thread.CurrentThread.ManagedThreadId);

            AddParams ap = new AddParams(30, 40);
            Thread t = new Thread(new ParameterizedThreadStart(Add));
            t.Start(ap);
            Thread.Sleep(5);
            Console.ReadLine();
        }
        static void Add(object data)
        {
            if (data is AddParams)
            {
                Console.WriteLine($"ID of thread in Add() {Thread.CurrentThread.ManagedThreadId}");
                AddParams addParams = (AddParams)data;

                Console.WriteLine($"{addParams.a} + {addParams.b} is {addParams.a + addParams.b}");
            }
        }
    }
}
