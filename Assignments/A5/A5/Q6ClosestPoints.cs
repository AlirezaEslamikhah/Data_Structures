using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;
using System.Linq;
namespace A5
{
    public class Q6ClosestPoints : Processor
    {
        public Q6ClosestPoints(string testDataName) : base(testDataName)
        { }
        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[], double>)Solve);

        public virtual double Solve(long n, long[] startSegments, long[] endSegment)
        {
            List<Tuple<long,long>> segs = new List<Tuple<long, long>>();
            for (int i = 0; i < n; i++)
            {
                Tuple<long,long> a = new Tuple<long, long>(startSegments[i],endSegment[i]);
                segs.Add(a);
            }
            return solution(segs);
        }

        private double solution(List<Tuple<long, long>> segs)
        {
            segs = segs.OrderByDescending(x=>x.Item1).ToList();
            long size = segs.Count();
            if (size<4)
            {
                return naive(segs);
            }
            Tuple<long, long>[] lhs = new Tuple<long, long>[size/2];
            for (int i = 0; i < (size/2); i++)
            {
                lhs[i] = segs[i];
            }
            Tuple<long, long>[] rhs = new Tuple<long, long>[size/2];
            for (int i = (int)(size/2); i < (size/2); i++)
            {
                lhs[i] = segs[i];
            }
            double left = solution(lhs.ToList());
            double right = solution(rhs.ToList());
            double result = Math.Min(left,right);
            if (result == 0.0)
            {
                return result;
            }
            long median = (lhs[size-1].Item1 + rhs[0].Item1)/2;
            List<Tuple<long,long>> close = new List<Tuple<long, long>>();
            for (int i = 0; i < lhs.Length;i++)
            {
                if (Math.Abs(lhs[i].Item1-median) < result)
                {
                    close.Add(lhs[i]);
                }
            }
            for (int j = 0; j < rhs.Length; j++)
            {
                if (Math.Abs(rhs[j].Item1-median) < result)
                {
                    close.Add(rhs[j]);
                }
            }
            close = close.OrderByDescending(x=> x.Item2).Reverse().ToList();
            for (int i = 0; i < close.Count()-1; i++)
            {
                for (int j = i+1; j < Math.Min(i+6,close.Count()) ;j++)
                {
                    if (Math.Abs(close[i].Item2 - close[j].Item2) < result)
                    {
                        result = Math.Min(result,distance(close[i],close[j]));
                    }
                }
            }
            return result;
        }

        private double naive(List<Tuple<long, long>> segs)
        {
            long size = segs.Count();
            if (size<2)
            {
                return 0.0;
            }
            double result = 0;
            for (int i = 0; i < size-1; i++)
            {
                for (int j = i+1; j < size; j++)
                {
                    result = Math.Min(result,distance(segs[i],segs[j]));
                }
            }
            return result;
        }

        private double distance(Tuple<long, long> tuple1, Tuple<long, long> tuple2)
        {
            double a = (tuple1.Item1 - tuple2.Item1) * (tuple1.Item1 - tuple2.Item1);
            double b = (tuple1.Item2 - tuple2.Item2) * (tuple1.Item2 - tuple2.Item2);
            return Math.Sqrt(a+b);
        }
    }
}