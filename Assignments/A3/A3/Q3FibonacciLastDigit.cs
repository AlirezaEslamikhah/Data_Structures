using System;
using TestCommon;

namespace A3
{
    public class Q3FibonacciLastDigit : Processor
    {
        public Q3FibonacciLastDigit(string testDataName) : base(testDataName) { }

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
                    b[i]=(b[i-1]+b[i-2])%10;
                }
                return b[n];
            }
            else
            {
                return b[n];
            }
        }
        
    }
}
