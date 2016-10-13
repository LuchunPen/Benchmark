/*
Copyright (c) Luchunpen (bwolf88).  All rights reserved.
Date: 29.07.2016 3:16:28
*/

using System;

namespace Nano3.Diagnostics
{
    public class BenchResult
    {
        private string _name;
        public string Name { get { return _name; } }
        private TimeSpan _elapsed;
        public TimeSpan Elapsed { get { return _elapsed; } }

        public BenchResult(string benchName, TimeSpan elapsed)
        {
            _name = benchName;
            _elapsed = elapsed;
        }

        public override string ToString()
        {
            return Name + ": " + Elapsed.TotalMilliseconds;
        }
    }
}
