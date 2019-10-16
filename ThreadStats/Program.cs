using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadStats
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread primaryThread = Thread.CurrentThread;
            primaryThread.Name = "PrimaryThread";

            Console.WriteLine($"Name of current AppDomain: {Thread.GetDomain().FriendlyName}");
            Console.WriteLine($"ID of the current context: {Thread.CurrentContext.ContextID}");
            Console.WriteLine($"Thread name: {primaryThread.Name}");
            Console.WriteLine($"Has thread started? : {primaryThread.IsAlive}");
            Console.WriteLine($"Priority level: {primaryThread.Priority}");
            Console.WriteLine($"Thread State: {primaryThread.ThreadState}");
            Console.ReadLine();
        }
    }
}
