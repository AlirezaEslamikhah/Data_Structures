using System;
using System.Collections.Generic;
using TestCommon;

namespace A9
{
    public class Q1ConvertIntoHeap : Processor
    {
        public Q1ConvertIntoHeap(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], Tuple<long, long>[]>)Solve);

        public static List<Tuple<long,long>>ans = new List<Tuple<long, long>>();
        public static int arr_s;
        // public static long[] s_array = new long[arr_s];
        public static List<long> s_array = new List<long>();
        public Tuple<long, long>[] Solve(long[] array)
        {
            s_array.Clear();
            ans.Clear();
            arr_s = array.Length;
            for (int i = 0; i < array.Length; i++)
            {
                // s_array[i] = array[i];
                s_array.Add(array[i]);
            }
            for (int i = array.Length/2; i >= 0; i--)
            {
                sift_down(i);
            }
            return ans.ToArray();
        }

        private void sift_down(int i)
        {
            long min = i;
            long l = l_child(i);
            long r = r_child(i);
            if (l != -1 && s_array[(int)l] < s_array[(int)min])
            {
                min = l;
            }
            if (r != -1 && s_array[(int)r] < s_array[(int)min])
            {
                min = r;
            }
            if (i != min)
            {
                Tuple<long,long> a = new Tuple<long, long>(i,min);
                ans.Add(a);
                long tmp = s_array[i];
                s_array[(int)i] = s_array[(int)min];
                s_array[(int)min] = tmp;
                sift_down((int) min);
            }
        }

        private long l_child(int i)
        {
            long l = (2 * i) + 1;
            if (l>= arr_s)
            {
                return -1;
            }
            return l;
        }

        private long r_child(int i)
        {
            long r = (2*i) + 2;
            if (r>= arr_s)
            {
                return -1;
            }
            return r;
        }
    }
}





        // private void sift_down(long v,long[] arr)
        // {
        //     long min = v;
        //     long l = 2 * v;
        //     if (l<arr.Length && arr[l] < arr[min])
        //     {
        //         min = l;
        //     }
        //     long r = (2 * v) + 1;
        //     if (r<arr.Length && arr[r]<arr[min])
        //     {
        //         min = r;
        //     }
        //     if (v != min)
        //     {
        //         Tuple<long,long> a = new Tuple<long, long>(v,min);
        //         ans.Add(a);
        //         long tmp = arr[v];
        //         arr[v] = arr[min];
        //         arr[min] = tmp;
        //         sift_down(min,arr);
        //     }
        // }