using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace BackGroundThread
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Background threads..");
            Printer p = new Printer();
            Thread backgroundThread = new Thread(new ThreadStart(p.PrintNumbers));

            backgroundThread.IsBackground = true;
            backgroundThread.Start();
            //Console.ReadLine();
        }
    }
}
