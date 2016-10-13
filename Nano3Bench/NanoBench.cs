/*
Copyright (c) Luchunpen (bwolf88).  All rights reserved.
Date: 29.07.2016 3:10:12
*/

using System;
using System.Diagnostics;
using System.Threading;

namespace Nano3.Diagnostics
{
    public static class NanoBench
    {
        public static BenchResult[] Run(Action action)
        {
            BenchAttribute attr = (BenchAttribute)action.Method.GetCustomAttributes(typeof(BenchAttribute), true)[0];
            if (attr == null) return null;

            action(); // cold run

            Stopwatch sw = new Stopwatch();
            BenchResult[] results = new BenchResult[attr.RunCount];
            Thread.CurrentThread.Priority = ThreadPriority.Highest;
            for (int i = 0; i < attr.RunCount; i++)
            {
                sw.Reset(); sw.Start();

                action();

                sw.Stop(); GC.Collect();
                results[i] = new BenchResult(attr.Name, sw.Elapsed);
            }
            Thread.CurrentThread.Priority = ThreadPriority.Normal;
            return results;
        }

        public static BenchResult[] Run<T1>(Action<T1> action, T1 param)
        {
            BenchAttribute attr = (BenchAttribute)action.Method.GetCustomAttributes(typeof(BenchAttribute), true)[0];
            if (attr == null) return null;

            action(param); // cold run

            Stopwatch sw = new Stopwatch();
            BenchResult[] results = new BenchResult[attr.RunCount];
            Thread.CurrentThread.Priority = ThreadPriority.Highest;
            for (int i = 0; i < attr.RunCount; i++)
            {
                sw.Reset(); sw.Start();

                action(param);

                sw.Stop(); GC.Collect();
                results[i] = new BenchResult(attr.Name, sw.Elapsed);
            }
            Thread.CurrentThread.Priority = ThreadPriority.Normal;
            return results;
        }

        public static BenchResult[] Run<T1, T2>(Action<T1, T2> action, T1 param1, T2 param2)
        {
            BenchAttribute attr = (BenchAttribute)action.Method.GetCustomAttributes(typeof(BenchAttribute), true)[0];
            if (attr == null) return null;

            action(param1, param2); // cold run

            Stopwatch sw = new Stopwatch();
            BenchResult[] results = new BenchResult[attr.RunCount];
            Thread.CurrentThread.Priority = ThreadPriority.Highest;
            for (int i = 0; i < attr.RunCount; i++)
            {
                sw.Reset(); sw.Start();

                action(param1, param2);

                sw.Stop(); GC.Collect();
                results[i] = new BenchResult(attr.Name, sw.Elapsed);
            }
            Thread.CurrentThread.Priority = ThreadPriority.Normal;
            return results;
        }

        public static BenchResult[] Run<T1, T2, T3>(Action<T1, T2, T3> action, T1 param1, T2 param2, T3 param3)
        {
            BenchAttribute attr = (BenchAttribute)action.Method.GetCustomAttributes(typeof(BenchAttribute), true)[0];
            if (attr == null) return null;

            action(param1, param2, param3); // cold run

            Stopwatch sw = new Stopwatch();
            BenchResult[] results = new BenchResult[attr.RunCount];
            Thread.CurrentThread.Priority = ThreadPriority.Highest;
            for (int i = 0; i < attr.RunCount; i++)
            {
                sw.Reset(); sw.Start();

                action(param1, param2, param3);

                sw.Stop(); GC.Collect();
                results[i] = new BenchResult(attr.Name, sw.Elapsed);
            }
            Thread.CurrentThread.Priority = ThreadPriority.Normal;
            return results;
        }
    }
}
