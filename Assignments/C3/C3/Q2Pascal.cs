using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TestCommon;

namespace C3
{
    public class Q2Pascal : Processor
    {
        public Q2Pascal(string testDataName) : base(testDataName)
        {
        }

        public override string Process(string inStr) => TestTools.Process(inStr, (Func<long, long>)Solve);

        public static long Solve(long n)
        {
            throw new NotImplementedException();
        }
    }
}
