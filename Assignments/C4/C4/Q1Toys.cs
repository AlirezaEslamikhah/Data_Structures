using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TestCommon;

namespace C4
{
    public class Q1Toys : Processor
    {
        public Q1Toys(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr)
        {
            var lines = inStr.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            var first = lines[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => long.Parse(d)).ToArray();
            long a = first[0];
            long [] arr = lines[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => long.Parse(d)).ToArray();
            return Solve(a, arr).ToString();
        }
        public static long Solve(long a, long[] arr)
        {
            long[] sum = new long[a];
            sum[0] = arr[a-1]; 
            for (int i = 1; i<a ;i++)
            {
                sum[i] = arr[a-i-1] + sum[i-1];
            }
            long[] ans = new long[a];
            int p = 2;
            int v = 3;
            ans[0] = arr[a-1];
            ans[1] = arr[a-2] + ans[0];
            ans[2] = arr[a-3] + ans[1];
            for (int i = (int) a-4; i >= 0 ; i--)
            {
                long q1 = arr[i] + sum[p] - ans[p];
                long q2 = (arr[i] + arr[i+1]) + sum[p-1] - ans[p-1];
                long q3 = (arr[i] + arr[i+1] + arr[i+2]) + sum[p-2] - ans[p-2];
                long tt = Math.Max(q1,q2);
                ans[v] = Math.Max(tt,q3);
                v++;
                p++;
            }
            
            return ans[a-1];
        }
    }
}
