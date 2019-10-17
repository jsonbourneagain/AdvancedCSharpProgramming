using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MultiThreadedPrinting
{
    public class Printer
    {
        private object threadLock = new object();
        public void PrintNumbers()
        {
            lock (threadLock)
            {
                for (int i = 0; i < 10; i++)
                {
                    // Put thread to sleep for a random amount of time.
                    Random r = new Random();
                    Thread.Sleep(1000 * r.Next(5));
                    Console.Write($"{i}");
                }
            }
        }
    }
}
