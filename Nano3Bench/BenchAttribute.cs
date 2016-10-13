/*
Copyright (c) Luchunpen (bwolf88).  All rights reserved.
Date: 29.07.2016 3:10:58
*/

using System;

namespace Nano3.Diagnostics
{
    [AttributeUsage(AttributeTargets.Method)]
    public class BenchAttribute : Attribute
    {
        private string _name;
        private int _runCount;

        public string Name { get { return _name; } }
        public int RunCount { get { return _runCount; } }

        public BenchAttribute(string name, int runCount)
        {
            if (runCount < 1) { throw new ArgumentOutOfRangeException("Run count < 1"); }

            _name = name;
            _runCount = runCount;
        }
    }
}
