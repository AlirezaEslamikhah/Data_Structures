using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TestCommon;

namespace C3
{
    public class Q1Array : Processor
    {
        public Q1Array(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) => TestTools.Process(inStr, (Func<long, long[], long>)Solve);
        public static long Solve(long n, long[] a)
        {
            long max = 0;
            long current = 0;
            for (int i = 0; i < n; i++)
            {
                current += a[i];
                if (current < 0)
                    current = 0; 
                if(max < current)
                    max = current;
            }
            return max;
        }
    }
}
