using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;
using System.Collections;


namespace A8
{
    public class Q3PacketProcessing : Processor
    {
        public Q3PacketProcessing(string testDataName) : base(testDataName)
        {
            ExcludeTestCaseRangeInclusive(3,22);
        }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[], long[]>)Solve);
        public static List<long> finish_time = new List<long>();
        public static long buff_size;
        public long[] Solve(long bufferSize, 
            long[] arrivalTimes, 
            long[] processingTimes)
        {
            buff_size = bufferSize;
            long[] responses = new long[arrivalTimes.Length];
            for (int i = 0; i < arrivalTimes.Length; i++)
            {
                responses[i] = procc(arrivalTimes[i],processingTimes[i]);
            }
            return responses;
        }

        private long procc(long arr, long pr)
        {
            flush(arr,pr);
            if (isfull())
            {
                return -1;
            }
            if (isempty())
            {
                finish_time.Add(arr + pr);
            }
            finish_time.Add(finish_time[finish_time.Count()-1] + pr);
            return finish_time[finish_time.Count()-1];
        }

        private bool isempty()
        {
            if (finish_time.Count() == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool isfull()
        {
            if (finish_time.Count() == buff_size)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private long response(bool v1, int v2)
        {
            throw new NotImplementedException();
        }

        private void flush(long arr, long pr)
        {
            while (finish_time.Count()>0)
            {
                if (finish_time[0] <= arr )
                {
                    finish_time.RemoveAt(0);
                }
                else
                {
                    break;
                }
            }
        }
    }
}