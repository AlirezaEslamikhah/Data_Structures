using System;
using TestCommon;

namespace A3
{
    public class Q9FibonacciSumSquares : Processor
    {
        public Q9FibonacciSumSquares(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>)Solve);
        
        public long calc(long m)
        {
            long prev = 0;
            long curr = 1;
            for (int i = 2; i <= m; i++)
            {
                long tmp = prev;
                prev = curr;
                curr = ((tmp % 10) + (curr % 10)) % 10;
            }
            return curr%10;
        }
        public static long get(long n)
        {
            Q8FibonacciPartialSum a = new Q8FibonacciPartialSum(" ");
            Q8FibonacciPartialSum b = new Q8FibonacciPartialSum(" ");
            long res = a.Solve(n,10);
            long res2 = b.Solve(n+1,10);
            long res3 = res * res2;
            return (res3)%10;
        }
        public long Solve(long n)
        {
            return get(n);
        }
    }
}
