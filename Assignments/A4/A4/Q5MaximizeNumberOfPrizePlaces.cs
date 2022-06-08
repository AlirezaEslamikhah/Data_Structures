using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q5MaximizeNumberOfPrizePlaces : Processor
    {
        public Q5MaximizeNumberOfPrizePlaces(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[]>) Solve);


        public virtual long[] Solve(long n)
        {
            var res = new List<long>();
            var sum = 1;
            while (n > 0)
            {
                res.Add(sum);
                n -= sum;
                sum ++;
                if (n < sum)
                {
                    var c = res.Count();
                    res[c-1] += n;
                    n = -1;
                }
            }
            return res.ToArray();
        }

    }
}

// int v = 0;
//             long[] sum = new long[n];
//             // List<long> sum = new List<long>();
//             long all = 1;
//             long start = 1;
//             sum[v] = start;
//             v++;
//             while (n-all > sum[sum.Last()])
//             {
//                 // sum.Append(sum[sum.Last()]+1);
//                 sum[v] = sum[sum.Last()]+1;v++;
//                 all+= sum[sum.Last()];
//             }
//             sum[sum.Last()] += (n-all);
//             return sum.ToArray();



// List<long>output = new List<long>();
            // long sum = 1;
            // if (n==1 || n==2 || n==0)
            // {
            //     output.Add(n);
            //     return output.ToArray();
            // }
            // output.Add(1);
            // long step = 1;
            // while (true)
            // {
            //     if ((sum + (step+1)) > (n-(sum + (step+1))))
            //     {
            //         output.Add(n-sum);
            //         return output.ToArray();
            //     }
            //     else
            //     {
            //         sum += step +1;
            //         step++;
            //         output.Add(step);
            //     }
            // }



// int v = 0;
//             long[] sum = new long[n];
//             // List<long> sum = new List<long>();
//             long all = 1;
//             long start = 1;
//             long step = 0;
//             sum[v] = start;
//             v++;
//             while (n-all > sum[step])
//             {
//                 // sum.Append(sum[sum.Last()]+1);
//                 sum[v] = sum[step]+1;v++;
//                 all+= sum[step];
//                 step++;
//             }
//             sum[step] += (n-all);
//             return sum;
//         }