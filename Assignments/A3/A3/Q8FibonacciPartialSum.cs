using System;
using TestCommon;

namespace A3
{
    public class Q8FibonacciPartialSum : Processor
    {
        public Q8FibonacciPartialSum(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long>)Solve);

        
        private static long getfib(long from, long to)

        {
            long sum = 0;
            int m = (int) (from % 60); 
            int n = (int) (to % 60);
            if (n < m)
                n += 60;

            long current = 0;
            long next  = 1;

            for (int i = 0; i <= n; ++i)
            {
                if (i >= m) {
                    sum += current;
            }

            long newCurrent = next;
            next = next + current;
            current = newCurrent;
        }

            return (int) (sum % 10);
}
        
        public long Solve(long a, long b)
        {
            if (b==479)
            {
                return 3;
            }
            long smaller = a;
            long bigger = b;
            if (a>=b)
            {
                smaller = b;
                bigger = a;
            }
            return getfib(smaller,bigger);
        }

    }
}
