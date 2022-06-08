using System;
using System.Collections.Generic;
using System.Linq;
using TestCommon;

namespace A9
{
    public class Q2MergingTables : Processor
    {

        public Q2MergingTables(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long[], long[]>)Solve);
        public static int parent_length;
        public static long[] parent = new long[300000];
        

        public long[] Solve(long[] tableSizes, long[] targetTables, long[] sourceTables)
        { 
            Array.Clear(parent,0,parent.Length);
            parent[0] = 0;
            parent_length = 0;
            parent_length = tableSizes.Length;
            // long[] ans = new long[targetTables.Length];
            List<long> ans = new List<long>();
            long[] rank = new long[tableSizes.Length +1];
            for (int i = 1; i < tableSizes.Length +1 ; i++)
            {
                parent[i] = i;
                rank[i] = tableSizes[i-1];
            }
            // ans.Add(rank.Max());
            for (int j = 0; j < targetTables.Length; j++)
            {
                long d = find(targetTables[j]);
                long s = find(sourceTables[j]);
                if (targetTables[j] != sourceTables[j] && d!=s)
                {
                    parent[s] = d;
                    rank[d] = rank[s] + rank[d];
                    ans.Add(rank.Max());
                }
                if (d == s && targetTables[j] != sourceTables[j] )
                {
                    ans.Add(rank.Max());
                }
                if (targetTables[j] == sourceTables[j])
                {
                    ans.Add(rank.Max());
                    
                }
            }
            return ans.ToArray();
        }

        private long find(long v)
        {
            while (v != parent[v])
            {
                v = parent[v];
            }
            return v;
        }
    }
}
