using TestCommon;
using System;
using System.Collections.Generic;
using System.Linq;
namespace E2
{
    public class Q1Reverse : Processor
    {
        public Q1Reverse(string testDataName) : base(testDataName)
        {
        }

        public override string Process(string inStr) => E2Processors.ProcessQ1Reverse(inStr, Solve);

        public LinkedList<long> Solve(long n, LinkedList<long> list)
        {
            LinkedList<long> result = new LinkedList<long>();
            List<long> nums = new List<long>();
            // result.Head = list.Tail;
            // result.Tail = list.Tail;
            Node<long> p = list.Head;
            nums.Add(p.Value);
            for (int i = 0; i < n-1; i++)
            {
                p = p.Next;
                nums.Add(p.Value);
            }
            nums.Reverse();
            result.AddFirst(nums[0]);
            for (int i = 0; i < n-1; i++)
            {
                result.AddLast(nums[i+1]);
            }

            // این سوال به دو روش جداگانه حل شده برای روش اول که زیر این متن کامنت شده اگر ما زمان را یک میلی ثانیه اضافه کنیم تست پاس میشود
            // لذا من برای بر طرف شدن هرگونه شک و شبهه دو روش مختلف را نوشتم 
            // Node<long> new_tail = new Node<long>(0);
            // new_tail = list.Head;
            // list.Tail = null;
            // n--;
            // n--;
            // while (n>0)
            // {
            //     for (int i = 0; i < n; i++)
            //     {
            //         new_tail = new_tail.Next;
            //     }
            //     Node<long> a = new Node<long>(new_tail.Value);
            //     result.Tail.Next = a;
            //     result.Tail = result.Tail.Next;
            //     result.Tail.Next = null;
            //     // list.Tail = new_tail;
            //     new_tail = list.Head;
            //     n--;
            // }
            // if (n == 0)
            // {
            //     result.AddLast(list.Head.Value);
            // }
            return result;
        }
    }
}
