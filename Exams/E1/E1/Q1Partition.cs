using System;
using TestCommon;
using System.Linq;
using System.Collections.Generic;

namespace E1
{
    public class Q1Partition : Processor
    {
        public Q1Partition(string testDataName) : base(testDataName)
        {
        }

        public override string Process(string inStr) => E1Processors.ProcessQ1Partition(inStr, Solve);

        public long Solve(long n, long x, long[] p)
        {
            long result = 0;
            List<Tuple<long,bool>> students = new List<Tuple<long, bool>>();
            for (int i = 0; i < n; i++)
            {
                Tuple<long,bool> a = new Tuple<long, bool>(p[i],true);
                students.Add(a);
            }
            students = students.OrderByDescending(x=>x.Item1).Reverse().ToList();
            for (int i = 0; i < n; i++)
            {
                if (students[i].Item2 == true && i<n-1)
                {
                    int k = i;
                    long temp = 1;
                    students[i] = new Tuple<long, bool>(students[i].Item1,false);
                    while (students[k+1].Item1-students[i].Item1<=x)
                    {
                        temp++;
                        k++;
                        students[k] = new Tuple<long, bool>(students[k].Item1,false);
                        if (k == n-1)
                        {
                            result++;
                            return result;
                        }
                    }
                    result ++;
                    
                }
                else if(i >= n-1)
                {
                    result++;
                    return result;
                }
            }
            return result;
        }
    }
}
