using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A8
{
    public class Q1CheckBrackets : Processor
    {
        public Q1CheckBrackets(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, long>)Solve);

        public long Solve(string str)
        {
            if (str.Length == 1 || str[0] == '}' ||str[0] == ')'|str[0] == ']' )
            {
                return 1;
            }
            Stack<Tuple<long,char>>stack = new Stack<Tuple<long,char>>();
            long index = 0;
            long ind = -1;
            foreach (char c in str)
            {
                ind ++;
                if ((stack.Count == 0) && (c == ')' || c == ']' || c =='}'))
                {
                    return ind+1;
                }
                if (c == '(' || c == '[' || c =='{')
                {
                    Tuple<long,char> a = new Tuple<long, char>(ind,c);
                    stack.Push(a);
                    index++;
                }
                else if(c == ')' || c == ']' || c =='}')
                {
                    if (stack.Count == 0)
                    {
                        return index + 1;
                    }
                    var top = stack.Pop();
                    if ((top.Item2 == '[' && c !=']') || (top.Item2 == '{' && c!='}') || (top.Item2 == '(' && c!= ')'))
                    {
                        return ind+1;
                    }
                    index++;
                }
            }
            if (stack.Count == 1)
            {
                foreach (var item in stack)
                {
                    return item.Item1 +1;
                }
            }
            
            return -1;
        }
    }
}
