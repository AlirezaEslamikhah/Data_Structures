using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A5
{
    public class Q2MajorityElement:Processor
    {

        public Q2MajorityElement(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);


        public virtual long Solve(long n, long[] a)
        {
            Array.Sort(a);
            long major = a[n/2];
            long count = 0;
            for (int i = 0; i < n-1; i++)
            {
                if (a[i] == major && i!= n/2)
                {
                    count++;
                }
            }
            if (count == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        private long majority(long low, long high, long[] a)
        {
            throw new NotImplementedException();
        }

        private long count(long[] a, long low, long high, long major)
        {
            long count = 0 ;
            for (int i = 1; i <= high; i++)
            {
                if (a[i] == major)
                {
                    count++;
                }
            }
            return count;
        }
    }
}








// long size = high - low+1;
            // if (size < 3)
            // {
            //     if (a[low] == a[high])
            //     {
            //         return a[low];
            //     }
            //     else
            //     {
            //         return -1;
            //     }
            // }
            // long pivot = (low + size)/2;
            // long l = majority(low,pivot,a);
            // long r = majority(pivot+1,high,a);
            // if (l==r)
            // {
            //     return r;
            // }
            // if (l==-1 && r == -1)
            // {
            //     return 0;
            // }
            // int count = 0;
            // int kount = 0;
            // for (int i = (int)low; i < high +1; i++)
            // {
            //     if (a[i]==l)
            //     {
            //         count++;
            //     }
            //     if (a[i]==r)
            //     {
            //         kount++;
            //     }
            // }
            // if (count > size/2)
            // {
            //     return l;
            // }
            // if (kount > size/2)
            // {
            //     return r;
            // }
            // else
            // {
            //     return 0;
            // }

            