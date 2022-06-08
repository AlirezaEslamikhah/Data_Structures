using System;
using TestCommon;

namespace A3
{
    public class Q6FibonacciMod : Processor
    {
        public Q6FibonacciMod(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long>)Solve);

        public long pisano(long m)
        {
            long prev = 0;
            long curr = 1;
            long res = 0;
            for (int i = 0; i < m * m; i++)
            {
                long temp = 0;
                temp = curr;
                curr = (prev + curr) % m;
                prev = temp;
    
                if (prev == 0 && curr == 1)
                    res = i + 1;
            }
            return res;
        }
        public long Solve(long n, long m)
        {
            long pisanoPeriod = pisano(m);
            n = n % pisanoPeriod;
            long prev = 0;
            long curr = 1;
            if (n == 0)
                return 0;
            else if (n == 1)
                return 1;
            for (int i = 0; i < n - 1; i++) {
                long temp = 0;
                temp = curr;
                curr = (prev + curr) % m;
                prev = temp;
            }
            return curr % m;
        }
    }
}

// def pisano(m):
//     before = 0
//     now = 1
//     for i in range(0,m*m):
//         # temp = now
//         # now = (temp+ now)%m
//         # before = temp
//         before , now = now , (before+now)%m
//         if now==1 and before == 0:
//             return i+1
// def fib_mod(x,y):
//     before = 0
//     now = 1
//     period = pisano(y)
//     x = x % period
//     if x == 0:
//         return 0
//     elif x==1:
//         return 1
//     for i in range(x-1):
//         before , now = now , (before+now)
//     return(now%y)


// print(fib_mod(tokens[0], tokens[1]))
