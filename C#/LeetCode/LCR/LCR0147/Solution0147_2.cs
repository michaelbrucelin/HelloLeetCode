using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0147
{
    public class Solution0147_2
    {
    }

    /// <summary>
    /// 栈 + 小顶堆
    /// </summary>
    public class MinStack_2 : Interface0147
    {
        public MinStack_2()
        {
            stack = new Stack<int>();
            minpq = new PriorityQueue<int, int>();
            buffer = new Dictionary<int, int>();
        }

        private Stack<int> stack;
        private PriorityQueue<int, int> minpq;
        private Dictionary<int, int> buffer;

        public int GetMin()
        {
            int min;
            while (buffer.ContainsKey(min = minpq.Peek()))
            {
                minpq.Dequeue();
                if (buffer[min] > 1) buffer[min]--; else buffer.Remove(min);
            }

            return min;
        }

        public void Pop()
        {
            int pop = stack.Pop();
            if (buffer.ContainsKey(pop)) buffer[pop]++; else buffer.Add(pop, 1);
        }

        public void Push(int x)
        {
            stack.Push(x);
            minpq.Enqueue(x, x);
        }

        public int Top()
        {
            return stack.Peek();
        }
    }
}
