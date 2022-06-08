using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace E2
{
    public class Q1ShortestPath: Processor
    {
        public Q1ShortestPath(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[][], long[]>)Solve);


        public static long[] Solve(long nodeCount, long[][] matrix)
        {
            List<long> result = new List<long>();
            List<long[][]> all= new List<long[][]>();
            long[][] first = new long [nodeCount][];
            for (int i = 0; i < nodeCount; i++)
            {
                first[i] = new long[nodeCount];
            }
            first = matrix;
            all.Add(first);
            long this_time = 0;
            for (int k = 1; k < nodeCount +1; k++)
            {
                long[][] A = new long[nodeCount][];
                for (int j = 0; j < nodeCount;j++)
                {
                    A[j] = new long[nodeCount];
                    for (int p = 0; p < nodeCount; p++)
                    {
                        if (j == p)
                        {
                            A[j][p] = 0;
                        }
                        else if (j == this_time || p == this_time)
                        {
                            A[j][p] = all[(int)this_time][j][p];
                        }
                        else
                        {
                            A[j][p] = Math.Min(all[k-1][j][p] ,all[k-1][j][j] + all[k-1][j][p]);
                        }
                    }
                }
                all.Add(A);
                this_time++;
            }
            int ind = all.Count - 1;
            for (int i = 0; i < nodeCount; i++)
            {
                for (int j = 0; j < nodeCount; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }
                    else
                    {
                        result.Add(all[ind][i][j]);
                    }
                }
            }
            return result.ToArray();
        }
    }
}
