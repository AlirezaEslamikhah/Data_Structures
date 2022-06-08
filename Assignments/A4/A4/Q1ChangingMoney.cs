using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q1ChangingMoney : Processor
    {
        public Q1ChangingMoney(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>) Solve);


        public virtual long Solve(long money)
        {
            long b = (money/10);
            long c = (money%10)/5;
            long d = (money%10)%5;
            return b+c+d;
        }
    }
}
// b = int(a/10)
// c = int((a%10)/5)
// d = (a%10)%5