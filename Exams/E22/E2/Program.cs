using System;

namespace E2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
//q1

// for(int itter=1;itter<=nodeCount;itter++)
//             {
//                 long[][] NewMatrix= matrix;
//                 for (int i=0;i<nodeCount;i++)
//                 {
//                     for (int j=0;j<nodeCount;j++)
//                     {
//                         if (i==itter-1 || j==itter-1 || i==j)
//                         {
//                             continue;
//                         }
//                         else
//                         {
//                             long min=matrix[i][j];
//                             if (min>matrix[i][itter-1]+matrix[itter-1][j])
//                             {
//                                 min=matrix[i][itter-1]+matrix[itter-1][j];
//                             }
//                             NewMatrix[i][j]=min;
//                         }
//                     }
//                     matrix=NewMatrix;
//                 }
//             }
//             List<long> result=new List<long>();
//             for(int i=0;i<nodeCount;i++)
//             {
//                 for(int j=0;j<nodeCount;j++)
//                 {
//                     if(matrix[i][j]!=0)
//                     {
//                         result.Add(matrix[i][j]);
//                     }
//                 }
//             }
//             return result.ToArray();


//q2
// long old=heap[change[0]];
//             heap[change[0]]+=change[1];
//             if(heap[change[0]]>old)
//             {
//                 siftdown(change[0],heap);
//             }
//             else{
//                 siftup(change[0],heap);
//             }
//             return heap.ToString();








// public void siftdown(long i,long[] tree)
//         {
//             long parnetIndex=(long)((i-1)/3);
//             long leftIndex=(long)((3*i)+1);
//             long vasatIndex=(long)((3*i)+2);
//             long rightIndex=(long)((3*i)+3);
//             long min=tree[leftIndex];
//             if(min>tree[vasatIndex])
//             {
//                 min=tree[vasatIndex];
//             }
//             if(min>tree[rightIndex])
//             {
//                 min=tree[rightIndex];
//             }
//             while(tree[i]>min && i<=tree.Length/3)
//             {
//                 if(min==tree[leftIndex])
//                 {
//                     (tree[i],tree[leftIndex])=(tree[leftIndex],tree[i]);
//                     i=leftIndex;
//                 }
//                 else if(min==tree[vasatIndex])
//                 {
                    
//                     (tree[i],tree[vasatIndex])=(tree[vasatIndex],tree[i]);
//                     i=vasatIndex;
//                 }
//                 else if(min==tree[rightIndex])
//                 {
        //             (tree[i],tree[rightIndex])=(tree[rightIndex],tree[i]);
        //             i=rightIndex;
        //         }
        //         parnetIndex=(long)((i-1)/3);
        //         leftIndex=(long)((3*i)+1);
        //         vasatIndex=(long)((3*i)+2);
        //         rightIndex=(long)((3*i)+3);
                


        //         if(leftIndex>tree.Length)
        //         {
        //             break;
        //         }
        //         if (vasatIndex>tree.Length)
        //         {
        //             min=tree[leftIndex];
        //             if (tree[i]>min)
        //             {
        //                 (tree[i],tree[leftIndex])=(tree[leftIndex],tree[i]);
        //             }
        //             break;
        //             // i=leftIndex;
        //         }
        //         if(rightIndex>tree.Length)
        //         {
        //             min=tree[leftIndex];
        //             if(min>tree[vasatIndex])
        //             {
        //                 min=tree[vasatIndex];
        //             }
        //             if(tree[i]>min)
        //             {
        //                 if(min==tree[leftIndex])
        //                 {
        //                     (tree[i],tree[leftIndex])=(tree[leftIndex],tree[i]);
        //                     // i=leftIndex;
        //                 }
        //                 else if(min==tree[vasatIndex])
        //                 {
        //                     (tree[i],tree[vasatIndex])=(tree[vasatIndex],tree[i]);
        //                     // i=vasatIndex;
        //                 }
        //             }
        //             break;
        //         }
                
        //         min=tree[leftIndex];
        //         if(min>tree[vasatIndex])
        //         {
        //             min=tree[vasatIndex];
        //         }
        //         if(min>tree[rightIndex])
        //         {
        //             min=tree[rightIndex];
        //         }
        //     }
        // }


    // public void siftup(long i,long[] tree)
    //     {
    //         while(i>0)
    //         {
    //             long parnetIndex=(long)((i-1)/3);
    //             if(tree[parnetIndex]>tree[i])
    //             {
    //             (tree[parnetIndex],tree[i])=(tree[i],tree[parnetIndex]);
    //             i=parnetIndex;
    //             }
    //         }
    //     }

// q3
// long max = (long)(bucketCount * 0.9);
//             string[] result = new string[max];
//             // long hash = GetBucketNumber("1", bucketCount);
//             long hash = GetBucketNumber("a", bucketCount);
//             long i = 0;
//             result[i++] = "a";
//             while (i < max)
//             {
//                 string newString = "";
//                 string str="a";
//                 while (GetBucketNumber(newString, bucketCount) != hash)
//                 {
//                     str.Append('a');
//                     newString = str.ToString();
//                 }
//                 result[i++] = newString;
//             }
//             return result;



// //q4
// if (libraryPrice<=roadPrice)
//             {
//                 return libraryPrice*nodeCount;
//             }
//             List<List<long>> adj=new List<List<long>>();
//             for(int i=1;i<=nodeCount;i++)
//             {
//                 List<long> l=new List<long>();
//                 for (int j=0;j<edgeCount;j++)
//                 {
//                     if(edges[j][0]==i)
//                     {
//                         l.Add(edges[j][1]-1);
//                     }
//                     if(edges[j][1]==i)
//                     {
//                         l.Add(edges[j][0]-1);
//                     }
//                 }
//                 adj.Add(l);
//             }
//             long scc=0;
//             long[] visited=new long[nodeCount];
//             for(int i=0;i<nodeCount;i++)
//             {
//                 if (visited[i]==0)
//                 {
//                     visited[i]=1;
//                     Queue<long> q = new Queue<long>();
//                     q.Enqueue(i);
//                     while(q.Count!=0)
//                     {
//                         int node=(int)q.Dequeue();
//                         for(int j=0;j<adj[node].Count;j++)
//                         {
//                             if(visited[adj[node][j]]==0)
//                             {
//                                 q.Enqueue(adj[node][j]);
//                                 visited[adj[node][j]]=1;
//                             }
//                         }
//                     }
//                     scc+=1;
//                 }
//             }
//             return scc*libraryPrice + (nodeCount-scc)*roadPrice;