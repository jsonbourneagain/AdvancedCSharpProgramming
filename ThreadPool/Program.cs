using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP = System.Threading;

namespace ThreadPool
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Main thread started. ThreadID: {TP.Thread.CurrentThread.ManagedThreadId}");
            Printer p = new Printer();
            TP.WaitCallback workItem = new TP.WaitCallback(PrintTheNumbers);

            for (int i = 0; i < 10; i++)
            {
                TP.ThreadPool.QueueUserWorkItem(workItem, p);
            }
            Console.WriteLine($"All tasks queued.");
            Console.ReadLine();
        }
        static void PrintTheNumbers(object state)
        {
            Printer task = (Printer)state;
            task.PrintNumbers();
        }
    }
}
