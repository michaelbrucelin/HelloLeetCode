using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0147
{
    public class Solution0147
    {
    }

    /// <summary>
    /// 栈 + 有序字典
    /// </summary>
    public class MinStack : Interface0147
    {
        public MinStack()
        {
            stack = new Stack<int>();
            smap = new SortedDictionary<int, int>();
        }

        private Stack<int> stack;
        private SortedDictionary<int, int> smap;

        public int GetMin()
        {
            return smap.First().Key;
        }

        public void Pop()
        {
            int pop = stack.Pop();
            smap[pop]--;
            if (smap[pop] == 0) smap.Remove(pop);
        }

        public void Push(int x)
        {
            stack.Push(x);
            if (smap.ContainsKey(x)) smap[x]++; else smap.Add(x, 1);
        }

        public int Top()
        {
            return stack.Peek();
        }
    }
}
