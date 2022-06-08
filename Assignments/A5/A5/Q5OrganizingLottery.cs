using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A5
{
    public class Q5OrganizingLottery:Processor
    {
        public Q5OrganizingLottery(string testDataName) : base(testDataName)
        {}
        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long[], long[]>)Solve);

        public virtual long[] Solve(long[] points, long[] startSegments, long[] endSegment)
        {
            Tuple<long,long>[] points_p = new Tuple<long, long>[points.Length];
            for (int i = 0; i <points.Length ; i++)
            {
                points_p[i] = new Tuple<long, long>(points[i],i);
            }
            points_p = points_p.OrderByDescending(x=>x.Item1).Reverse().ToArray();
            Array.Sort(startSegments);
            Array.Sort(endSegment);
            long[] res = new long[points.Length];
            var c = 0;
            var oi = 0;
            var ci = 0;
            var size = startSegments.Length;
            foreach (var point in points_p)
            {
                while (oi<size && startSegments[oi] <= point.Item1)
                {
                    oi++;
                    c++;
                }
                while (ci<size && endSegment[ci] < point.Item1)
                {
                    ci++;
                    c--;
                }
                // res.Add(c);'
                var x = point.Item2;
                res[x] = c;

            }
            return res.ToArray();
        }
    }
}














// long[]point_c = new long[points.Length];
            // // List<long> point_c = new List<long>();
            // // Array.Copy(points,point_c,points.Length);
            // List<Tuple<long,long>> tuples= new List<Tuple<long, long>>(); 
            // for (int i = 0; i < startSegments.Length; i++)
            // {
            //     Tuple<long,long> a = new Tuple<long,long>(startSegments[i],endSegment[i]);
            //     tuples.Add(a);
            // }
            // List<Tuple<long,long>> points_l= new List<Tuple<long, long>>(); 
            // for (int i = 0; i < points.Length; i++)
            // {
            //     Tuple<long,long> a = new Tuple<long,long>(points[i],i);
            //     points_l.Add(a);
            // }
            // tuples = tuples.OrderByDescending(x => x.Item1).Reverse().ToList();
            // points_l = points_l.OrderByDescending(x=>x.Item1).Reverse().ToList();
            // var count =0;var v = 0;
            // foreach (var point in points_l)
            // {
            //     while (v<tuples.Count() && point.Item1>tuples[v].Item1 && point.Item1 < tuples[v].Item2)
            //     {
            //         count++;
            //         v++;
            //     }
            //     point_c[(int)point.Item2] = count;
            //     count = 0;
            //     v= 0;
            // }
            // return point_c;












