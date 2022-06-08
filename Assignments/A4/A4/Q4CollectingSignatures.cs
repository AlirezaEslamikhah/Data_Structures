using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q4CollectingSignatures : Processor
    {
        public Q4CollectingSignatures(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[], long>) Solve);


        public virtual long Solve(long tenantCount, long[] startTimes, long[] endTimes)
        {
            int v = 0;
            // Tuple<long,long>[] points = new Tuple<long,long>[tenantCount];
            long[] points = new long[tenantCount];
            List<Tuple<long,long>> x = new List<Tuple<long,long>>();
            for (int i = 0; i < startTimes.Length; i++)
            {
                x.Add(new Tuple<long, long>(startTimes[i],endTimes[i]));
            }
            x = x.OrderBy(y => y.Item2).ToList();
            long point = x[0].Item2;
            points[v] = point;
            v++;
            foreach (var s in x)
            {
                if (s.Item1 >point)
                {
                    points[v] = s.Item2;v++;
                    point = s.Item2;
                }
            }
            return v;
        }
    }
}
