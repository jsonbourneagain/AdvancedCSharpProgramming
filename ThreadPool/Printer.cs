using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace ThreadPool
{
    public class Printer
    {
        public void PrintNumbers()
        {
            Console.WriteLine($"{Thread.CurrentThread.Name} is executing PrintNumbers().");
            Console.Write("Your numbers:");
            for (int i = 0; i < 10; i++)
            {
                Console.Write($"{i}");
                Thread.Sleep(500);
            }
            Console.WriteLine();
        }
    }
}
