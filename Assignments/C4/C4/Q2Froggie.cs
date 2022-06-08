using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TestCommon;

namespace C4
{
    public class Q2Froggie : Processor
    {
        public Q2Froggie(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long[][], long>)Solve);


        public virtual long Solve(long n, long p, long[][] numbers)
        {
            long[] ar1 = new long[n];
            long[] ar2 = new long[n];
            for (int i = 0; i < n; i++)
            {
                ar1[i] = numbers[0][i];
                ar2[i] = numbers[1][i];
            }
            long[] res1 = new long[n];
            long[] res2 = new long[n];
            res1[0] = ar1[0];
            res2[0] = ar2[0];
            for (int i = 1; i < n; i++)
            {
                long w = res1[i-1] + ar1[i];
                long x = (res2[i-1] - p) + ar1[i];
                res1[i] = Math.Max(w,x);
                
                long y = (res1[i-1]-p) + ar2[i];
                long z = (res2[i-1]) + ar2[i];
                res2[i] = Math.Max(y,z);
            }
            long pa1 = res1[n-1];
            long pa2 = res2[n-1];
            return Math.Max(pa1,pa2);
        }
    }
}
