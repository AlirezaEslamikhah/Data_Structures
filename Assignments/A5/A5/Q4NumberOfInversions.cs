using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;


namespace A5
{
    public class Q4NumberOfInversions:Processor
    {

        public Q4NumberOfInversions(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);

        public virtual long Solve(long n, long[] a)
        {
            long[] aux = new long[n];
            for (int i = 0; i < n; i++)
            {
                aux[i] = a[i];
            }
            return mergesort(a,aux,0,n-1);
        }

        private long mergesort(long[] a,long[]aux, long low, long high)
        {
            if (low >= high)
            {
                return 0;
            }
            long mid = low + ((high - low)/2);
            long incount = 0;
            incount += mergesort(a,aux,low,mid);
            incount += mergesort(a,aux,mid+1,high);
            incount += merge(a,aux,low,mid,high);
            return incount;
        }

        private long merge(long[] a,long[]aux, long low, long mid, long high)
        {
            long k = low;long i = low;
            long j = mid + 1;
            long incount = 0;
            while (i<= mid && j<=high)
            {
                if (a[i]<=a[j])
                {
                    aux[k] = a[i];
                    i++;
                }
                else
                {
                    aux[k] = a[j];
                    j++;
                    incount += (mid-i+1);
                }
                k++;
            }
            while (i<= mid)
            {
                aux[k] = a[i];
                i++;
                k++;
            }
            for (long u = low; u < high + 1; u++)
            {
                a[u] = aux[u];
            }
            return incount;
        }
    }
}











// int inv_count = 0;
 
            // for (int i = 0; i < n - 1; i++)
            //     for (int j = i + 1; j < n; j++)
            //         if (a[i] > a[j])
            //             inv_count++;
    
            // return inv_count;