using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TestCommon;

namespace C7
{
    public class Q1TopView : Processor
    {
        public Q1TopView(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) => C7Processors.ProcessQ1TopView(inStr, Solve);
        

        public string Solve(long n, BinarySearchTree tree)
        {
            
        }
    }
}
























// var main = tree.root;
            // string result = "";
            // result += $" {main.info}";
            // while (main.left != null)
            // {
            //     result += $" {main.left.info}";
            //     main = main.left;
            // }
            // var main2 = tree.root;
            // while (main2.right != null)
            // {
            //     result += $" {main2.right.info}";
            //     main2 = main2.right;
            // }
            // return result;