using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A5
{
    public class Q1BinarySearch : Processor
    {
        public Q1BinarySearch(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long [], long[]>)Solve);


        public virtual long[] Solve(long []a, long[] b) 
        {
            List<long> results = new List<long>();
            foreach (var key in b)
            {
                int l = 0;
                int r = a.Length -1;
                while (l <= r)
                {
                    int mid = l + ((r-l)/2);
                    if (a[mid] == key)
                    {
                        results.Add(mid);
                        break;
                    }
                    if (a[mid]<key)
                    {
                        l = mid + 1;
                    }
                    else
                    {
                        r = mid -1;
                    }
                }
                if (l >r)
                {
                    results.Add(-1);
                }
            }
            return results.ToArray();

        }

        private long binary(long[] a, long low, long high, long key)
        {

            if (low > high)
            {
                return -1;
            }
            long mid = low + ((high - low)/2);
            if (key == a[mid])
                return mid;
            if (key < a[mid])
            {
                return binary(a,low,mid-1,key);
            }
            else
            {
                return binary(a,mid+1,high,key);
            }
        }
    }
}
// Array.Sort(a);
            // int size = a.Length;
            // long[] c = new long[size];
            // for (int i = 0; i < size; i++)
            // {
            //     c[i] = binary(a,0,size-1,b[i]);
            // }
            // return c;