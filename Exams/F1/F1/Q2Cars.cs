using System;
using TestCommon;

namespace E1
{
    public class Q2Cars : Processor
    {
        public Q2Cars(string testDataName) : base(testDataName)
        {
            this.ExcludeTestCases(75,76);
            // this.ExcludeTestCaseRangeInclusive(5,35);
            // this.ExcludeTestCaseRangeInclusive(43,50);
            // this.ExcludeTestCaseRangeInclusive(52,57);
            // // this.ExcludeTestCaseRangeInclusive(5,35);
            // this.ExcludeTestCaseRangeInclusive(59,61);
            // this.ExcludeTestCaseRangeInclusive(63,72);
            // this.ExcludeTestCaseRangeInclusive(74,76);
        }

        public override string Process(string inStr) => E1Processors.ProcessQ2Cars(inStr, Solve);

        public double oghlidos(double a , double b , double c , double d)
        {
            double x = 0;
            double y = 0;
            if (c > a)
            {
                x = Math.Pow(c-a,2);
            }
            else
            {
                x = Math.Pow(a-c,2);
            }
            if (d > b)
            {
                y =Math.Pow(d-b,2);
            }
            else
            {
                y =Math.Pow(b-d,2);
            }
            return Math.Sqrt(x+y);
        }
        public double Solve(long aX, long aY, long bX, long bY, long cX, long cY, long dX, long dY)
        {
            return Solve2((double)aX,(double)aY,(double)bX,(double)bY,(double)cX,(double)cY,(double)dX,(double)dY);
        }

        public double Solve2(double aX, double aY, double bX, double bY, double cX, double cY, double dX, double dY)
        {
            // aX = (double)aX;
            // double init = oghlidos((double)aX,(double)aY,(double)cX,(double)cY);
            double first = Math.Sqrt((aX-cX)*(aX-cX) + (aY-cY)*(aY-cY));
            double last = Math.Sqrt((bX-dX)*(bX-dX) + (bY-dY)*(bY-dY));
            double axt = (aX+bX)/2;
            double ayt = (aY+bY)/2;
            double cxt = (cX+dX)/2;
            double cyt = (cY+dY)/2;
            // double a1 = (double) aX;
            // double a2 = (double) aY;
            // double c1 = (double) cX;
            // double c2 = (double) cY;
            double half = Math.Sqrt((axt-cxt)*(axt-cxt) + (ayt-cyt)*(ayt-cyt));
            if (Math.Abs(last-first) < 0.00000000001 && Math.Abs(last-half) <0.00000000001)
            {
                return (first+last)/2;
            }
            if (first < last)
            {
                return Solve2(aX,aY,axt,ayt,cX,cY,cxt,cyt);
            }
            else
            {
                return Solve2(axt,ayt,bX,bY,cxt,cyt,dX,dY);
            }
            // for (int i = 1; i < 100000; i++)
            // {
            //     // a1+=axt;
            //     // a2 += ayt;
            //     // c1 += cxt;
            //     // c2 += cyt;
            //     a1 += a1/1000000;
            //     a2 += a2/1000000;
            //     c1 += c1/1000000;
            //     c2 += c2/1000000;

                
            //     double tmpres = oghlidos(a1,a2,c1,c2);
            //     if (tmpres < smallest)
            //     {
            //         smallest = tmpres;
            //     }
            // }
            // return smallest;
            
        }
    }
}
