using System;
using System.Collections.Generic;
using System.Linq;
using TestCommon;
// using System.Linq;
namespace C1
{
    public class Q1 : Processor
    {
        public Q1(string testDataName) : base(testDataName)
        {
        }

        public override string Process(string inStr)
        {
            var lines = inStr.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            var first = lines[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => long.Parse(d)).ToArray();
            long n = first[0];
            long x = first[1];
            long [] a = lines[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => long.Parse(d)).ToArray();
            return Solve(n, a, x).ToString();
        }

        public long Solve(long n, long[] a, long x)
        {
            long output = 0;
            long ext=0;
            for (int i = 0 ; i < a.Length; i++)
            {
                if (a[i] >= x)
                {
                    ext = ext + (a[i]-x);
                    output++;
                }
                if (a[i]<x)
                {
                    long rem = x-a[i];
                    if (a[i]+ext >= x)
                    {
                        ext = ext - rem; 
                        output++;
                    }
                    else
                    {
                        return output;
                    }
                }
            }
            return output;
        }
    }
}
