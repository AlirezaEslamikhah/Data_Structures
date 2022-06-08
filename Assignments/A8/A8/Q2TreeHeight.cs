using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;


namespace A8
{
    public class Q2TreeHeight : Processor
    {
        public Q2TreeHeight(string testDataName) : base(testDataName)
        {
            // this.ExcludeTestCaseRangeInclusive(21,24);
        }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);

        public long Solve(long nodeCount, long[] tree)
        {
            long root = 0;
            node[] nodes = new node[nodeCount];
            for (long i = 0; i < nodeCount; i++)
            {
                nodes[i] = new node(i);
            }
            for (int i = 0; i < tree.Length; i++)
            {
                var parent = tree[i];
                if (parent == -1)
                {
                    root = i;
                }
                else
                {
                    nodes[parent].addchild(nodes[i]);
                }
            }
            return height(nodes[root]);

        }

        public long height(node n)
        {
            if (n == null)
            {
                return 0;
            }
            Queue<node>q = new Queue<node>();
            q.Enqueue(n);
            long result = 0;
            while (true)
            {
                long qc = q.Count();
                if (qc == 0)
                {
                    return result;
                }
                result++;
                while (qc > 0 )
                {
                    node new_node = q.Peek();
                    q.Dequeue();
                    foreach (var nd in new_node.children)
                    {
                        if (nd != null)
                        {
                            q.Enqueue(nd);
                        }
                    }
                    qc--;
                }
            }
        }
    }
    public  class node
    {
        public long data;
        public List<node>children = new List<node>();
        // private long i;

        public void addchild(node a)
        {
            children.Add(a);
        }

        public node(long data, node child)
        {
            this.data = data;
            this.children.Add(child);
        }
        public node()
        {}

        public node(long i)
        {
            this.data = i;
        }
    }
}
