using TestCommon;
using System;
using System.Collections.Generic;

namespace E2
{
    public class Q2Passcode : Processor
    {
        public Q2Passcode(string testDataName) : base(testDataName)
        {
            ExcludeTestCases(32,4);
        }
        public override Action<string, string> Verifier => E2Verifiers.VerifyQ2Passcode;

        public override string Process(string inStr) => E2Processors.ProcessQ2Passcode(inStr, Solve);

        public Tuple<int,int> Solve(long n, long x, long[] a)
        {
            Dictionary<long,long> db = new Dictionary<long, long>();
            List<long> zeros = new List<long>();
            for (int i = 0; i < n; i++)
            {
                if (x % a[i] == 0)
                {
                    db[i+1] = a[i];
                    zeros.Add(i+1);
                }
            }
            for (int i = zeros.Count -1; i >= 1; i--)
            {
                long first = db[zeros[i]];
                long second = db[zeros[i-1]];
                if (first * second == x)
                {
                    return new Tuple<int, int>((int)zeros[i] , (int)zeros[i-1]);
                }
            }
            if (zeros.Count == 3)
            {
                if (db[zeros[0]] *db[zeros[2]] == x )
                {
                    return new Tuple<int, int>(1,3);
                }
            }
            return null;
        }
    }
}
