using System;
using System.Collections.Generic;
using TestCommon;

namespace A10
{
    public class Q3RabinKarp : Processor
    {
        public Q3RabinKarp(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, string, long[]>)Solve);

        public static int d = 256;
        public static int q = 101;
        public long[] Solve(string pattern, string text)
        {
            List<long> result = new List<long>();
            int M = pattern.Length;
            int N = text.Length;
            int i, j; 
            int p = 0; 
            int t = 0; 
            int h = 1; 
            for (i = 0; i < M-1; i++) 
                h = (h*d)%q; 
            for (i = 0; i < M; i++) 
            { 
                p = (d*p + pattern[i])%q; 
                t = (d*t + text[i])%q; 
            }
            for (i = 0; i <= N - M; i++) 
            { 
                if ( p == t ) 
                { 
                    for (j = 0; j < M; j++) 
                    { 
                        if (text[i+j] != pattern[j]) 
                            break; 
                    } 
                    if (j == M) 
                        // Console.WriteLine("Pattern found at index " + i); 
                        result.Add(i);
                } 
                if ( i < N-M ) 
                { 
                    t = (d*(t - text[i]*h) + text[i+M])%q; 
                    if (t < 0) 
                    t = (t + q); 
                } 
            }
            return result.ToArray();
        }

        public const long BigPrimeNumber = 1000000007;
        public const long ChosenX = 263;

        public static long PolyHash(string str,long p,long x)
        {
            long hash = 0;
            for (int i = str.Length -1; i >= 0; i--)
            {
                hash = (hash * x +str[i]) % p;
            }
            return hash;
        }

        public static long[] PreComputeHashes(string T, long P, long prime, long x)
        {
            long t = T.Length;
            long p = P;
            string s = T.Substring((int)(t-p));
            long[] H = new long[t-p+1];
            H[t-p] = PolyHash(s,BigPrimeNumber,ChosenX)%(t-p+1);
            long y = 1;
            for (int i = 1; i < p+1; i++)
            {
                y = (y * ChosenX) % BigPrimeNumber;
            }
            for (long i = t-p-1; i >= 0; i--)
            {
                H[i] = (ChosenX * H[i+1] + T[(int)i] - y * T[(int)(i+p)]) % BigPrimeNumber;
            }
            return H;
        }
    }
}


// List<long> occurrences = new List<long>();
//             int startIdx = 0;
//             int foundIdx = 0;
//             while ((foundIdx = text.IndexOf(pattern, startIdx)) >= startIdx)
//             {
//                 startIdx = foundIdx + 1;
//                 occurrences.Add(foundIdx);
//             }
//             return occurrences.ToArray();



// long t = text.Length;
//             long p = pattern.Length;
//             List<long> result = new List<long>();
//             long pattern_hash = PolyHash(pattern,BigPrimeNumber,ChosenX) % (t-p+1);
//             long[] hash_substring = new long[(t-p+1)];
//             hash_substring = PreComputeHashes(text,pattern.Length,BigPrimeNumber,ChosenX);
//             for (int i = 0; i < t-p+1; i++)
//             {
//                 if (pattern_hash == hash_substring[i])
//                 {
//                     result.Add(i);
//                 }
//             }
//             return result.ToArray();