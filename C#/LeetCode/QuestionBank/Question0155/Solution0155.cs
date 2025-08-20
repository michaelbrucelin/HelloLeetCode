using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0155
{
    public class Solution0155
    {
    }

    /// <summary>
    /// 栈 + 堆 + hash表
    /// 栈用来实现栈，堆用来取最小值，hash表用来标记删除的元素（懒删除）
    /// </summary>
    public class MinStack : Interface0155
    {
        public MinStack()
        {
            stack = new Stack<int>();
            minpq = new PriorityQueue<int, int>();
            map = new Dictionary<int, int>();
        }

        private Stack<int> stack;
        private PriorityQueue<int, int> minpq;
        private Dictionary<int, int> map;

        public int GetMin()
        {
            int key = minpq.Peek();
            while (map.ContainsKey(key))
            {
                minpq.Dequeue();
                if (map[key] > 1) map[key]--; else map.Remove(key);
                key = minpq.Peek();
            }

            return minpq.Peek();
        }

        public void Pop()
        {
            int key = stack.Pop();
            if (map.ContainsKey(key)) map[key]++; else map.Add(key, 1);
        }

        public void Push(int val)
        {
            stack.Push(val);
            minpq.Enqueue(val, val);
        }

        public int Top()
        {
            return stack.Peek();
        }
    }
}
