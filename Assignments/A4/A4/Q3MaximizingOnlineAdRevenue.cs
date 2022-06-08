using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q3MaximizingOnlineAdRevenue : Processor
    {
        public Q3MaximizingOnlineAdRevenue(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[], long>) Solve);


        public virtual long Solve(long slotCount, long[] adRevenue, long[] averageDailyClick)
        {
            // long[] f = new long[adRevenue.Length];
            // long[] s = new long[adRevenue.Length];
            // for (int i = 0; i <adRevenue.Length ; i++)
            // {
            //     f[i] = adRevenue[i];
            //     s[i] = 
            // }
            Array.Sort(adRevenue);
            Array.Sort(averageDailyClick);
            long sum = 0 ;
            for (int i = 0; i < slotCount; i++)
            {
                sum = sum + adRevenue[i] * averageDailyClick[i];
            }
            return sum;
        }
    }
}
// f = []
// s = []
// for i in range(len(first)):
//     f.append(int(first[i]))
//     s.append(int(second[i]))
// f.sort() 
// s.sort()
// sum = 0
// for i in reversed(range(a)):
//     sum  = sum + f[i] * s[i]
// print(sum)