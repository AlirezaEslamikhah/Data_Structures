using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q2MaximizingLoot : Processor
    {
        public Q2MaximizingLoot(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[], long>) Solve);


        public virtual long Solve(long capacity, long[] weights, long[] values)
        {
            double rem = 0;
            var unit = new (double w,double v,double vpw)[values.Length];
            for (int i = 0; i < values.Length; i++)
            {
                unit[i].w = weights[i];
                unit[i].v = values[i];
                unit[i].vpw = unit[i].v / unit[i].w ; 
            }
            unit = unit.OrderByDescending(x =>x.vpw).ToArray();
            for (int i = 0; i < values.Length; i++)
            {
                var a = Math.Min(capacity,unit[i].w);
                rem += a * unit[i].vpw;
                capacity -= (long) a;
                if (rem <= 0)
                {
                    return (long) rem;
                }
            }
            return (long) rem;
        }

        public override Action<string, string> Verifier { get; set; } =
            TestTools.ApproximateLongVerifier;
    }
}
// while(capa < bag_capacity):
//     number = 0 
//     for i in range(len(values)):
//         if (values[i]/capacities[i]) >denest:
//             number = i
//             denest = values[i]/capacities[i]
//     if capacities[number] <= bag_capacity:
//         capa += capacities[number]
//         output+= values[number]
//         values[number] = 0
//     else:
//         output = values[number] / (capacities[number]/bag_capacity)
//         break

// print (format(output, '.4f'))




// long output =0;
//             long capa = 0;
//             long denest = 0;
//             while (capa < capacity)
//             {
//                 long number = 0;
//                 for (int i = 0; i < values.Length; i++)
//                 {
//                     if ((values[i]/weights[i]) > denest)
//                     {
//                         number = i;
//                         denest = values[i]/weights[i];
//                     }
//                 }
//                 if (weights[number] <= capacity)
//                 {
//                     capa += weights[number];
//                     output += weights[number];
//                     values[number] = 0;

//                 }
//                 else
//                 {
//                     output = values[number] / (weights[number]/capacity);
//                     break;
//                 }
//             }
//             return output;










//  long[] A = new long[weights.Length];
//             long v = 0;
//             for (int i = 0; i < values.Length; i++)
//             {
            //     for (int p = 0; p < A.Length; p++)
            //     {
            //         A[p] = 0;
            //     }
            //     long max = 0;
            //     for (int j = 0; j < values.Length; j++)
            //     {
            //         if (weights[j] > 0 && values[j]/weights[j] > max)
            //         {
            //             max = j;
            //         }
            //     }
            //     long a = 0;
            //     if (weights[max] <capacity)
            //     {
            //         a = weights[max];
            //     }
            //     else
            //     {
            //         a = capacity;
            //     }
            //     v = v + (a * (values[max]/weights[max]));
            //     weights[max] -= a;
            //     A[max] += a;
            //     capacity -= a;
            // }
            // return v;