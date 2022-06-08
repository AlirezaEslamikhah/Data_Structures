using TestCommon;
using System;
using System.Collections.Generic;

namespace E2
{
    public class Q4ChainingProfiler : Processor
    {
        public Q4ChainingProfiler(string testDataName) : base(testDataName)
        {
            ExcludeTestCaseRangeInclusive(36,45);
            ExcludeTestCases(22,32,34);
        }

        /// <summary>
        /// FNV-1a - (Fowler/Noll/Vo) is a fast, consistent, non-cryptographic hash algorithm with good dispersion. (see http://isthe.com/chongo/tech/comp/fnv/#FNV-1a)
        /// </summary>
        private static int GetFNV1aHashCode(string str, int bucketCount)
        {
            if (str == null)
                return 0;
            var length = str.Length;
            int hash = length;
            for (int i = 0; i != length; ++i)
                hash = (hash ^ str[i]) * 16777619;
            return (hash % bucketCount + bucketCount) % bucketCount;
        }

        public override string Process(string inStr) => E2Processors.ProcessQ4ChainingProfiler(inStr, Solve);

        // Returns:
        //      A Tuple:
        //          Item1 = Adjusted sample variance of the chain lengths
        //          Item2 = Hash table, a list of length bucketCount
        public Tuple<double, List<LinkedList<string>>> Solve(int n, int bucketCount, string[] s)
        {
            List<LinkedList<string>> result  = new List<LinkedList<string>>();
            for (int i = 0; i < bucketCount; i++)
            {
                LinkedList<string> a = new LinkedList<string>();
                result.Add(a);
            }
            for (int i = 0; i < s.Length; i++)
            {
                Add(s[i],ref result,bucketCount);
            }
            double varianc = variance(bucketCount,ref result);
            Tuple<double, List<LinkedList<string>>> b = new Tuple<double, List<LinkedList<string>>>(varianc,result);
            return b;
        }

        private double variance(int bucketCount, ref List<LinkedList<string>> result)
        {
            double sum = 0;
            double e = 0;
            for (int i = 0; i < bucketCount; i++)
            {
                sum += result[i].Size();
            }
            double average =sum / bucketCount;
            for (int i = 0; i < bucketCount; i++)
            {
                e += Math.Pow(Math.Abs(result[i].Size() - average) , 2);
            }
            return (e / (bucketCount -1));
        }

        private void Add(string str, ref List<LinkedList<string>> result,int bucketcount)
        {
            int hash = GetFNV1aHashCode(str,bucketcount);
            Node<string> p = result[hash].Head;
            while (p != null)
            {
                if (p.Value == str)
                {
                    return;
                }
                p = p.Next;
            }
            result[hash].AddLast(str);
        }
    }
}
