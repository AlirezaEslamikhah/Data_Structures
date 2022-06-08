using System;
using System.Collections.Generic;
using System.Linq;
using TestCommon;
namespace A10
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> a = new List<int>{4,5,6,7,8,9,3,2,11,43};
            List<int> result = a.Prepend(0).ToList();
            var tmp = a;
            a = result;
            for (int i = 0; i < a.Count; i++)
            {
                System.Console.WriteLine(a[i]);
            }
            // Creating an array of numbers
//             var ti = new List<int> { 1, 2, 3 };

// // Prepend and Append any value of the same type
//             var results = ti.Prepend(0).Append(4);

// // output is 0, 1, 2, 3, 4
//             Console.WriteLine(string.Join(", ", results ));
        }
    }
}
