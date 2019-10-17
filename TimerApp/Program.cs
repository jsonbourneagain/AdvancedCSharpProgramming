using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TimerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"*** Working with Timer type ***");
            TimerCallback timeCB = new TimerCallback(PrintTime);
            Timer t = new Timer(timeCB, "Hello from Main()", 0, 1000);

            // You can also discard t as it's not used anywhere.
            //Timer _ = new Timer(timeCB, "Hello from Main()", 0, 1000);

            Console.WriteLine($"Hit enter key to terminate");
            Console.ReadLine();
        }
        static void PrintTime(object state)
        {
            Console.WriteLine($"Time is: {DateTime.Now.ToLongTimeString()} Message: {state.ToString()}");
        }
    }
}
