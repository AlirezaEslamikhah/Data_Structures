
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TestCommon;

namespace C2
{
    public class Q2Chocolate : Processor
    {
        public Q2Chocolate(string testDataName) : base(testDataName)
        {
        }

        public override string Process(string inStr) => TestTools.Process(inStr, (Func<long, long[], long>)Solve);

        public static long Solve(long n, long[] a)
        {
            long[] f = new long[n];
            long sum = 0;
            for (int i = 0; i < f.Length; i++)
            {
                f[i] = 1;
            }
            for (int j = 0; j < (f.Length)-1; j++)
            {
                if (a[j+1]>a[j])
                {
                    f[j+1] = f[j] + 1;
                }
            }
            for (int p = a.Length-1; p >= 1 ; p--)
            {
                if (a[p-1]>a[p] && f[p-1] <= f[p])
                {
                    f[p-1] = f[p] +1;
                }
            }
            // return(f.Sum());
            for (int u = 0; u < f.Length; u++)
            {
                sum += f[u];
            }
            return sum;
        }
    }
}
