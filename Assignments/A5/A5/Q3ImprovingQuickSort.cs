using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A5
{
    public class Q3ImprovingQuickSort:Processor
    {
        public Q3ImprovingQuickSort(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[]>)Solve);

        public virtual long[] Solve(long n, long[] a)
        {
            randomizedQuickSort(a, 0, n - 1);
            return a;
        }

        private void randomizedQuickSort(long[] a, long lower, long higher)
        {
            if (lower >= higher)
            {
                return;
            }
            long[] m = partition(a,lower,higher);
            randomizedQuickSort(a,lower,m[1]-1);
            randomizedQuickSort(a,m[2]+1,higher);
        }

        private long[] partition(long[] a, long lower, long higher)
        {
            long i = lower; long k = lower;long p = higher;
            while (i<p)
            {
                if (a[i]<a[higher])
                {
                    swap(ref a[i],ref a[k]);
                    i++;k++;
                }
                else if(a[i]==a[higher])
                {
                    p--;
                    swap(ref a[i],ref a[p]);
                }
                else
                {
                    i++;
                }
            }
            var m = Math.Min(p-k,higher-p+1);
            for (int j = 0; j < k+m-1; j++)
            {
                if (higher-m+1+j <= higher)
                {
                    swap(ref a[k+j],ref a[higher-m+1+j]);
                    
                }
            }
            return new long[]{i,k,p};
        }

        private void swap(ref long v1,ref long v2)
        {
            long temp;
            temp = v1;
            v1 = v2;
            v2 = temp;
        }
    }
}
