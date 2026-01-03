using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0622
{
    public class Solution0622
    {
    }

    /// <summary>
    /// 模拟
    /// 没读懂题目中的描述与 队列 以及 循环 有什么关系
    /// </summary>
    public class MyCircularQueue : Interface0622
    {
        public MyCircularQueue(int k)
        {
            queue = new int[k];
            tail = 0;
            this.k = k;
        }

        private int[] queue;
        private int tail, k;

        public bool EnQueue(int value)
        {
            if (tail == k) return false;
            queue[tail++] = value;
            return true;
        }

        public bool DeQueue()
        {
            if (tail == 0) return false;
            tail--;
            return true;
        }

        public int Front()
        {
            if (tail == 0) return -1;
            return queue[0];
        }

        public int Rear()
        {
            if (tail == 0) return -1;
            return queue[tail - 1];
        }

        public bool IsEmpty()
        {
            return tail == 0;
        }

        public bool IsFull()
        {
            return tail == k;
        }
    }
}
