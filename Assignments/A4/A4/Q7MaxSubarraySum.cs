using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q7MaxSubarraySum : Processor
    {
        public Q7MaxSubarraySum(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);


        public virtual long Solve(long n, long[] numbers)
        {
            long max = 0;
            long current = 0;
            for (int i = 0; i < n; i++)
            {
                current += numbers[i];
                if (current < 0)
                    current = 0; 
                if(max < current)
                    max = current;
            }
            return max;
        }
    }
}
