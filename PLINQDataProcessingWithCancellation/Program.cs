using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PLINQDataProcessingWithCancellation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press any key to start processing");
            Console.ReadKey();
            Console.WriteLine($"Processing");
            Task.Factory.StartNew(() => ProcessIntData());
            Console.ReadLine();
        }
        static void ProcessIntData()
        {
            int[] source = Enumerable.Range(1, 10_000_000).ToArray();
            int[] modThreeIsZero = (from num in source
                                    where num % 3 == 0
                                    orderby num descending
                                    select num
                                    ).ToArray();
            Console.WriteLine($"Found {modThreeIsZero.Count()} numbers that match query!");
        }
    }
}
