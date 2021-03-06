using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TestCommon;

namespace C2
{
    public class Q1FlowerShop : Processor
    {
        public Q1FlowerShop(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr)
        {
            var lines = inStr.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            var first = lines[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => long.Parse(d)).ToArray();
            long a = first[0];
            long b = first[1];
            long [] p = lines[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => long.Parse(d)).ToArray();
            return Solve(a, b, p).ToString();
        }
        public static long Solve(long a, long b, long[] p)
        {
            Array.Sort(p);
            Array.Reverse(p);
            long sum = 0;
            long martabe = 0;
            for (int i = 0; i < a; i++)
            {
                sum += (martabe+1) * p[i];
                if (((i+1)%b)==0)
                {
                    martabe++;
                }
            }
            return sum;
        }
    }
}
