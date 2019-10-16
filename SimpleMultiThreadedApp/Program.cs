using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace SimpleMultiThreadedApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"*** The Amazing Thread App *** \n");
            Console.Write("Do you want [1] or [2] threads?");

            string threadCount = Console.ReadLine();

            Thread primaryThread = Thread.CurrentThread;
            primaryThread.Name = "Primary";

            Console.WriteLine($"{Thread.CurrentThread.Name} is executing Main().");
            Printer p = new Printer();

            switch (threadCount)
            {
                case "2":
                    Thread backGroundThread = new Thread(new ThreadStart(p.PrintNumbers));
                    backGroundThread.Name = "Secondary";
                    backGroundThread.Start();
                    break;
                case "1":
                    p.PrintNumbers();
                    break;
                default:
                    Console.WriteLine($"I don't know what you want...you get 1 thread.");
                    goto case "1";
            }
            MessageBox.Show("I'm busy!", "Work on main thread...");
            Console.ReadLine();
        }
    }
}
