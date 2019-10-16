using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SynchronousDelegateReview
{
    public delegate int BinaryOp(int a, int b);
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Main() invoked on thread {Thread.CurrentThread.ManagedThreadId}");
            BinaryOp binary = new BinaryOp(Add);
            IAsyncResult asyncResult = binary.BeginInvoke(10, 20, null, null);
            //int ans = binary(10, 20);
            // while (!asyncResult.IsCompleted) you can do this too.

            while (!asyncResult.AsyncWaitHandle.WaitOne(1000, true))
            {
                Console.WriteLine("Doing more work in Main()!");
                //Thread.Sleep(1000);
            }
            // These lines will not execute until
            // the Add() method has completed.
            int ans = binary.EndInvoke(asyncResult);
            Console.WriteLine("10 + 20 is {0}.", ans);
            Console.ReadLine();
        }
        static int Add(int x, int y)
        {
            Console.WriteLine($"Add() invoked on thread {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(5000);
            return x + y;
        }
    }
}
