using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncCallBackDelegate
{
    public delegate int BinaryOp(int x, int y);
    class Program
    {
        private static bool isDone = false;
        static void Main(string[] args)
        {
            Console.WriteLine("***** AsyncCallbackDelegate Example *****");
            Console.WriteLine("Main() invoked on thread {0}.",
            Thread.CurrentThread.ManagedThreadId);
            BinaryOp b = new BinaryOp(Add);
            IAsyncResult ar = b.BeginInvoke(10, 10,
            new AsyncCallback(AddComplete), "Thank you Main() for adding these numbers.");
            // Assume other work is performed here...
            while (!isDone)
            {
                Console.WriteLine("Working....");
                Thread.Sleep(1000);
            }
            Console.ReadLine();
        }
        static int Add(int x, int y)
        {
            Console.WriteLine("Add() invoked on thread {0}.", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(5000);
            return x + y;
        }
        static void AddComplete(IAsyncResult iar)
        {
            Console.WriteLine("AddComplete() invoked on thread {0}.", Thread.CurrentThread.
            ManagedThreadId);
            Console.WriteLine("Your addition is complete");
            // Now get the result
            AsyncResult asyncresult = (AsyncResult)iar;
            BinaryOp b = (BinaryOp)asyncresult.AsyncDelegate;
            Console.WriteLine($"10 + 10 is {b.EndInvoke(iar)}");
            // Retrieve the additional message object and cast it to string.
            string msg = (string)iar.AsyncState;
            Console.WriteLine(msg);
            isDone = true;
        }
    }
}
