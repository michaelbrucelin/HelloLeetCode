﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0933
{
    public class Solution0933_2
    {
    }

    /// <summary>
    /// 队列
    /// </summary>
    public class RecentCounter_2 : Interface0933
    {
        public RecentCounter_2()
        {
            queue = new Queue<int>();
        }

        private Queue<int> queue;

        public int Ping(int t)
        {
            queue.Enqueue(t);
            int target = t - 3000;
            while (queue.Count > 0 && queue.Peek() < target) queue.Dequeue();

            return queue.Count;
        }
    }
}
