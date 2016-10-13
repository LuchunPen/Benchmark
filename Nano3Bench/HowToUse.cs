using System;
using System.Collections.Generic;
using Nano3.Diagnostics;

namespace Nano3Bench
{
    class HowToUse
    {
        static void Main(string[] args)
        {
            BenchResult[] br = NanoBench.Run(TestCycle1);
            BenchResult[] br2 = NanoBench.Run(TestCycle2, 1000000);

            for (int i = 0; i < br.Length; i++) {
                Console.WriteLine(br[i]);
            }
            Console.WriteLine();
            for (int i = 0; i < br2.Length; i++) {
                Console.WriteLine(br2[i]);
            }

            Console.ReadLine();
        }

        [Bench("Cycle int", 5)]
        private static void TestCycle1()
        {
            List<int> values = new List<int>();
            for (int i = 0; i < 1000000; i++) {
                values.Add(i);
            }
        }

        [Bench("Cycle long", 5)]
        private static void TestCycle2(int count)
        {
            List<long> values = new List<long>();
            for (int i = 0; i < count; i++) {
                values.Add(i);
            }
        }
    }
}
