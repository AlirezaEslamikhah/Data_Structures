using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TestCommon;

namespace E2
{
    public class Q2ThreeChildrenMinHeap : Processor
    {
        public Q2ThreeChildrenMinHeap(string testDataName) : base(testDataName) { }
        public override string Process(string inStr)
        {
            return TestTools.Process(inStr, (Func<long,long[],long[], string>)Solve);
        }
        public string Solve(long n,long[] change,long[] heap)
        {
            throw new NotImplementedException();
            
        }
        
        
    }
}
