using System;
using TestCommon;

namespace A3
{
    public class Q4GCD : Processor
    {
        public Q4GCD(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long>)Solve);

        public long Solve(long a, long b)
        {
            long d;
            while(b!=0){
                d = a % b;
                a = b;
                b = d;
            }
            return a;
        }
    }
    
}
// def gcd(tks):
    // i = 0
    // if tks[0]!=0 and tks[1]!=0:
    //     b =[]
    //     tks.sort()
    //     for i in range(2):
    //         b.append(tks[i])
    //     c = b[1]%b[0]
    //     tks[0] = c
    //     tks[1] = b[0]
    //     return gcd(tks)
    // else:
    //     tks.sort()
    //     print(tks[1])