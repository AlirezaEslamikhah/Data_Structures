using System;
using TestCommon;

namespace A3
{
    public class Q7FibonacciSum : Processor
    {
        public Q7FibonacciSum(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>)Solve);

        
        public long Solve(long n)
        {
            int f0 = 0;
            int f1 = 1;
            if (n == 0)
                return 0;
            if (n == 1)
                return 1;
            else
            {
                int rem = (int)(n % 60);
                if(rem == 0)
                return 0;
                for(int i = 2; i < rem + 3; i++)
                {
                int f = (f0 + f1) % 60;
                f0 = f1;
                f1 = f;
                }
                int s = f1 - 1;
                return s%10;
                }
            }
    }
}
// sum = 1
// d = []
// def get_index(m):
//     global sum
//     global d
//     now = 1 
//     before = 0 
//     d.append(before)
//     d.append(now)
//     for i in range(58):
//         before , now = now, (before+now)
//         sum = (sum + now)%10
//         d.append(sum)
//     return d[m%60]