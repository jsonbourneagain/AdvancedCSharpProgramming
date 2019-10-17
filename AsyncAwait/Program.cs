using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine($"Fun with Async await");
            List<int> l = default;
            //Console.WriteLine(DoWorkAsync());
            string message = await DoWorkAsync();
            Console.WriteLine(message);
            Console.WriteLine("Completed");
            Console.ReadLine();
        }
        static string DoWork()
        {
            Thread.Sleep(5_000);
            return "Done with work!";
        }
        static async Task<string> DoWorkAsync()
        {
            return await Task.Run(() =>
            {
                Thread.Sleep(5_000);
                return "Done with work";
            });
        }
        static async Task MethodWithProblems(int firstParam, int secondParam)
        {
            Console.WriteLine($"Enter");
            if (secondParam < 0)
            {
                Console.WriteLine($"Bad data");
                return;
            }
            ActualImplementation();
            async Task ActualImplementation()
            {
                await Task.Run(() =>
                {
                    Thread.Sleep(4000);
                    Console.WriteLine($"First complete");
                    Console.WriteLine($"Something bad happened.");
                });
            }
        }
    }
}
