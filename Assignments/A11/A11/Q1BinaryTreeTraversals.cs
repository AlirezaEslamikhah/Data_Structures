using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A11
{
    public class Q1BinaryTreeTraversals : Processor
    {
        public Q1BinaryTreeTraversals(string testDataName) : base(testDataName) { }
        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[][], long[][]>)Solve);


        public class node
        {
            public long key;
            public node right = null;
            public node left = null;
            public bool is_root = false;

            public node()
            {
            }

            public node(long key ,node left,node right)
            {
                this.key = key;
                this.left = left;
                this.right = right;
            }
        }
        public static List<long> inorder = new List<long>();
        public static List<long> preorder = new List<long>();
        public static List<long> postorder = new List<long>();
        public long[][] Solve(long[][] nodes)
        {
            inorder.Clear();preorder.Clear();postorder.Clear();
            long[][] result = new long[3][]; 
            node[] tree = new node[nodes.Length];
            // result[0] = new long[5];
            // result[0][3] = 2;
            for (int i = 0; i < 3; i++)
            {
                result[i] = new long[nodes.Length];
            }
            for (int i = 0; i < tree.Length; i++)
            {
                tree[i]  = new node();
                tree[i].key = nodes[i][0];
            }
            for (int i = 0; i < nodes.Length; i++)
            {
                tree[i].key = nodes[i][0];
                if (nodes[i][1] != -1)
                {
                    tree[i].left = tree[nodes[i][1]];
                }
                if (nodes[i][2] != -1)
                {
                    tree[i].right = tree[nodes[i][2]];
                }
                if (i ==0)
                {
                    tree[i].is_root = true;
                }
            }
            inorder_travesal(tree[0],ref tree);
            preorder_traversal(tree[0],ref tree);
            postorder_traversal(tree[0],ref tree);
            result[0] = inorder.ToArray();
            result[1] = preorder.ToArray();
            result[2] = postorder.ToArray();
            return result;
        }

        public void postorder_traversal(node node, ref node[] tree)
        {
            if (node == null)
            {
                return;
            }
            postorder_traversal(node.left,ref tree);
            postorder_traversal(node.right,ref tree);
            postorder.Add(node.key);
        }

        public void preorder_traversal(node node, ref node[] tree)
        {
            if (node == null)
            {
                return;
            }
            preorder.Add(node.key);
            preorder_traversal(node.left,ref tree);
            preorder_traversal(node.right,ref tree);
        }

        public void inorder_travesal(node node, ref node[] tree)
        {
            if (node == null)
            {
                return;
            }
            inorder_travesal(node.left,ref tree);
            inorder.Add(node.key);
            inorder_travesal(node.right,ref tree);
            
        }
    }
}

