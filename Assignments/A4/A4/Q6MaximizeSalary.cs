using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q6MaximizeSalary : Processor
    {
        public Q6MaximizeSalary(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], string>) Solve);

        public static bool greater(long a , long b)
        {
            // string A = a.ToString();
            // string B = b.ToString();
            // string c = A+B;
            string A = $"{a}{b}";
            string B = $"{b}{a}";
            if (int.Parse(A)> int.Parse(B))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public virtual string Solve(long n, long[] numbers)
        {
            // List<long>outt = new List<long>();
            var nums = numbers.ToList();
            string outt = "";
            while (nums.Count()>0)
            {
                long max = 0;
                foreach (var x in nums)
                {
                    if (greater(x,max))
                    {
                        max = x;
                    }
                }
                outt += max.ToString();
                nums.Remove(max);
            }
            return outt;
        }
    }
}
// def isGreatOrEqual(a, b):
//     if a + b > b + a:
//         return True
//     else:
//         return False
// def largest_number(a):
//     #write your code here
//     res = ""
//     while len(a) > 0:
//         maxDigit = '0'
//         for x in a:
//             if isGreatOrEqual(x, maxDigit):
//                 maxDigit = x
//         res += maxDigit
//         a.remove(maxDigit)
//     return res

