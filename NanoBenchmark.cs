/*
Copyright (c) Luchunpen.
Date: 29.07.2016. Last edit 02.10.2023.
*/

using System;
using System.Diagnostics;
using System.Threading;

namespace Nano3.Diagnostics
{
    public static class Benchmark
    {
        public class BenchmarkResult
        {
            public int TestNum { get; private set; }
            public string TestName { get; private set; }
            public TimeSpan ElapsedTime { get; private set; }

            public BenchmarkResult(int test_num, string test_name, TimeSpan elapsed_time)
            {
                TestNum = test_num;
                TestName = test_name;
                ElapsedTime = elapsed_time;
            }

            public override string ToString()
            {
                return string.Format("[{0}] [{1}] [{2} ms]", TestNum, TestName, ElapsedTime.TotalMilliseconds);
            }
        }

        /// <param name="action">Tested action</param>
        /// <param name="runs_count">Number of runs</param>
        /// <param name="test_name">Test name</param>
        /// <returns></returns>
        public static BenchmarkResult[] Run(Action action, uint runs_count, string test_name = null)
        { 
            if (action == null) { throw new ArgumentNullException(); }

            string m_name = (string.IsNullOrEmpty(test_name)) ? action.Method.Name : test_name;

            action(); // cold run

            Stopwatch sw = new Stopwatch();
            BenchmarkResult[] results = new BenchmarkResult[runs_count];
            Thread.CurrentThread.Priority = ThreadPriority.Highest;
            for (int i = 0; i < runs_count; i++)
            {
                sw.Reset(); sw.Start();

                action();

                sw.Stop(); 
                GC.Collect();

                results[i] = new BenchmarkResult(i + 1, m_name, sw.Elapsed);
            }
            Thread.CurrentThread.Priority = ThreadPriority.Normal;
            return results;
        }

        /// <param name="action">Tested action</param>
        /// <param name="param">Action param</param>
        /// <param name="runs_count">Number of runs</param>
        /// <param name="test_name">Test name</param>
        /// <returns></returns>
        public static BenchmarkResult[] Run<T1>(Action<T1> action, T1 param, uint runs_count = 1, string test_name = null)
        {
            if (action == null) { throw new ArgumentNullException(); }

            string m_name = (string.IsNullOrEmpty(test_name)) ? action.Method.Name : test_name;

            action(param); // cold run

            Stopwatch sw = new Stopwatch();
            BenchmarkResult[] results = new BenchmarkResult[runs_count];
            Thread.CurrentThread.Priority = ThreadPriority.Highest;
            for (int i = 0; i < runs_count; i++)
            {
                sw.Reset(); sw.Start();

                action(param);

                sw.Stop(); 
                GC.Collect();

                results[i] = new BenchmarkResult(i + 1, m_name, sw.Elapsed);
            }
            Thread.CurrentThread.Priority = ThreadPriority.Normal;
            return results;
        }


        /// <param name="action">Tested action</param>
        /// <param name="param1">First action param</param>
        /// <param name="param2">Second action param</param>
        /// <param name="runs_count">Number of runs</param>
        /// <param name="test_name">Test name</param>
        /// <returns></returns>
        public static BenchmarkResult[] Run<T1, T2>(Action<T1, T2> action, T1 param1, T2 param2, uint runs_count = 1, string test_name = null)
        {
            if (action == null) { throw new ArgumentNullException(); }

            string m_name = (string.IsNullOrEmpty(test_name)) ? action.Method.Name : test_name;

            action(param1, param2); // cold run

            Stopwatch sw = new Stopwatch();
            BenchmarkResult[] results = new BenchmarkResult[runs_count];
            Thread.CurrentThread.Priority = ThreadPriority.Highest;
            for (int i = 0; i < runs_count; i++)
            {
                sw.Reset(); sw.Start();

                action(param1, param2);

                sw.Stop(); 
                GC.Collect();

                results[i] = new BenchmarkResult(i + 1, m_name, sw.Elapsed);
            }
            Thread.CurrentThread.Priority = ThreadPriority.Normal;
            return results;
        }
    }
}
