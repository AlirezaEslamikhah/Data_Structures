using System;
using System.Collections.Generic;
using System.Linq;
using TestCommon;

namespace A10
{
    public class Q2HashingWithChain : Processor
    {
        public Q2HashingWithChain(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, string[], string[]>)Solve);

        public class pair
        {
            public long key;
            public string value;
            public pair(long key,string value)
            {
                this.key = key;
                this.value = value;
            }
        }
        public static List<string> result = new List<string>();
        
        public static long bc ;
        public string[] Solve(long bucketCount, string[] commands)
        {
            bc = 0;
            bc = bucketCount;
            result.Clear();
            List<string>[] chain = new List<string>[bucketCount];
            for (int i = 0; i < bucketCount; i++)
            {
                // List<string> a = new List<string>();
                chain[i] = new List<string>();
            }

            foreach (var cmd in commands)
            {
                var toks = cmd.Split();
                var cmdType = toks[0];
                var arg = toks[1];
                switch (cmdType)
                {
                    case "add":
                        Add(arg,ref chain,bucketCount);
                        break;
                    case "del":
                        Delete(arg,ref chain,bucketCount);
                        break;
                    case "find":
                        result.Add(Find(arg,ref chain,bucketCount));
                        break;
                    case "check":
                        result.Add(Check(int.Parse(arg),ref chain));
                        break;
                }
            }
            return result.ToArray();
        }


        public const long BigPrimeNumber = 1000000007;
        public const long ChosenX = 263;

        public static long PolyHash(
            string str, int start, int count,
            long p = BigPrimeNumber, long x = ChosenX)
        {
            long hash = 0;
            for (int i = str.Length -1; i >= 0; i--)
            {
                hash = (hash * x +str[i]) % p;
            }
            return hash%bc;
        }

        public void Add(string str, ref List<string>[] chain,long b_)
        {
            long hash = PolyHash(str,0,0,BigPrimeNumber,ChosenX);
            // var a = chain[hash];
            if (hash > b_)
            {
                return;
            }
            foreach (string item in chain[hash])
            {
                if (item == str)
                {
                    return;
                }
            }
            if (chain[hash].Count()==0)
            {
                chain[hash].Add(str);
            }
            else
            {
                List<string> res = chain[hash].Prepend(str).ToList();
                var tmp = chain[hash];
                chain[hash] = res;
            }
        }

        public string Find(string str,ref List<string>[] chain,long b_)
        {
            long hash = PolyHash(str,0,0,BigPrimeNumber,ChosenX);
            if (hash > b_)
            {
                return "no";
            }
            foreach (string item in chain[hash])
            {
                if (str == item)
                {
                    return "yes";
                }
            }
            return "no";
        }

        public void Delete(string str,ref List<string>[] chain,long b_)
        {
            long hash = PolyHash(str,0,0,BigPrimeNumber,ChosenX);
            // var rmv= "";
            List<string> rmv = new List<string>();
            if (hash > b_)
            {
                return;
            }
            foreach (string item in chain[hash])
            {
                if (str == item)
                {
                    // chain[hash].Remove(str);
                    // rmv = str;
                    rmv.Add(str);
                }
            }
            foreach (var item in rmv)
            {
                chain[hash].Remove(item);
            }
        }

        // public string Check(int i)
        // {
        //     if ()
        //     {
                
        //     }
        //     return "";
        // }
        private string Check(int v, ref List<string>[] chain)
        {
            string res = "";
            if (chain[v].Count() == 0)
            {
                return "-";
            }
            else
            {
                foreach (var item in chain[v])
                {
                    res += item + " ";
                }
                return res.Trim();
            }
        }
    }
}
