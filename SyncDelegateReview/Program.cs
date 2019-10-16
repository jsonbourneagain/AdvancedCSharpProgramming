using System;
using System.Threading;

namespace SyncDelegateReview
{
    public delegate int BinaryOp(int x, int y);

    class Program
    {
        //public delegate int BinaryOp(int x, int y);
        static void Main(string[] args)
        {
            Console.WriteLine($"Main() invoked on thread {Thread.CurrentThread.ManagedThreadId}");
            BinaryOp binary = new BinaryOp(Add);
            IAsyncResult asyncResult = binary.BeginInvoke(10, 20, null, null);
            //int ans = binary(10, 20);

            int ans = binary.EndInvoke(asyncResult);
            // These lines will not execute until
            // the Add() method has completed.
            Console.WriteLine("Doing more work in Main()!");
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
