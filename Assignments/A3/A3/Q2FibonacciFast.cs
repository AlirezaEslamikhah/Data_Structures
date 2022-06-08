using System;
using System.Collections.Generic;
using TestCommon;

namespace A3
{
    public class Q2FibonacciFast : Processor
    {
        public Q2FibonacciFast(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>)Solve);

        public long Solve(long n)
        {
            long[]b = new long[n+2];
            b[0]=0;b[1]=1;
            if (n>=2)
            {
                for (int i = 2; i < n+1; i++)
                {
                    b[i]=(b[i-1]+b[i-2]);
                }
                return b[n];
            }
            else
            {
                return b[n];
            }
        }
    }
    // if n >= 2:
    //     for i in range(2,n+1):
    //         b.append(b[i-1]+b[i-2])
    //     print(b[n])
    // else:
    //     print(b[n])
}
