using System;
using System.Collections.Generic;
using TestCommon;

namespace A9
{
    public class Q4ParallelProcessing : Processor
    {
        public Q4ParallelProcessing(string testDataName) : base(testDataName) {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], Tuple<long, long>[]>)Solve);

        public class _thread
        {
            public long id;
            public long time;
            public _thread(long i,long t)
            {
                this.id = i;
                this.time = t;
            }
        }

        public class min_heap
        {
            public _thread[] _threads = new _thread[100000];
            private long size = 0;
            public long org_size;
            public min_heap()
            {
                
            }
            public void sift_down(int i)
            {
                long min = i;
                long min_by_index_l = _threads[i].id;
                long min_by_index_r = _threads[i].id;
                long l = l_child(i);
                long r = r_child(i);
                if (l != -1 && _threads[(int)l].time < _threads[(int)min].time)
                {
                    min = l;
                }
                if (r != -1 && _threads[(int)r].time < _threads[(int)min].time)
                {
                    min = r;
                }
                if (l != -1 && _threads[(int)l].time == _threads[(int)min].time)
                {
                    if (_threads[(int)l].id < _threads[(int)min].id)
                    {
                        min = l;
                    }
                }
                if (r != -1 && _threads[(int)r].time == _threads[(int)min].time)
                {
                    if (_threads[(int)r].id < _threads[(int)min].id)
                    {
                        min = r;
                    }
                }
                if (i != min)
                {
                    _thread tmp = _threads[i];
                    _threads[(int)i] = _threads[(int)min];
                    _threads[(int)min] = tmp;
                    sift_down((int) min);
                }
            }
            private long l_child(int i)
            {
                long l = (2 * i) + 1;
                if (l>= size)
                {
                    return -1;
                }
                return l;
            }
            private long r_child(int i)
            {
                long r = (2*i) + 2;
                if (r>= size)
                {
                    return -1;
                }
                return r;
            }
            private long parent(long i)
            {
                long p = ((i-1)/2); 
                if (p >= size)
                {
                    return -1;
                }
                return p;
            }
            public _thread extract_min()
            {
                _thread result = _threads[0];
                _threads[0] = _threads[size-1];
                size --;
                sift_down(0);
                return result;
            }
            // public long thread_c;
            public void insert(_thread a)
            {
                if(org_size == size)
                {
                    return;
                }
                if (size == 0)
                {
                    _threads[0] = a;
                    size++;
                }
                else
                {
                    _threads[size] = a;
                    size++;
                    sift_up(size-1);
                }
            }

            public void sift_up(long i)
            {
                long p = parent(i);
                if (i>0 && p != -1 && _threads[p].time != _threads[i].time)
                {
                    while (i>0 && _threads[(int)p].time>_threads[(int)i].time)
                    {
                        _thread tmp = _threads[i];
                        long pp = parent(i);
                        _threads[(int)i] = _threads[(int)p];
                        _threads[(int)p] = tmp;
                        i = pp;
                    }
                }
                else if(_threads[p].time == _threads[i].time)
                {
                    if (i>0&& p!= -1 && _threads[(int)p].id>_threads[(int)i].id)
                    {
                        _thread tmp = _threads[i];
                        _threads[(int)i] = _threads[(int)p];
                        _threads[(int)p] = tmp;
                        i = parent(i);
                    }
                }
            }
        }
        public Tuple<long, long>[] Solve(long threadCount, long[] jobDuration)
        {
            long _id = 0;
            min_heap tree = new min_heap();
            tree.org_size = threadCount;
            Tuple<long,long>[] answer = new Tuple<long,long>[jobDuration.Length];
            for (int i = 0; i < threadCount; i++)
            {
                _thread t = new _thread(_id,0);
                tree.insert(t);
                _id++;
            }
            for (int i = 0; i < jobDuration.Length; i++)
            {
                _thread t = tree.extract_min();
                answer[i] = new Tuple<long, long>(t.id,t.time);
                _thread v = new _thread(t.id,t.time+jobDuration[i]);
                tree.insert(v);
            }
            return answer;
        }
    }
}
