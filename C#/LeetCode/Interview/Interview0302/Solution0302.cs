using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview0302
{
    public class Solution0302
    {
    }

    /// <summary>
    /// 双栈
    /// 1个栈做为栈来使用，另一个栈记录最小值
    /// </summary>
    public class MinStack : Interface0302
    {
        public MinStack()
        {
            stack = new Stack<int>();
            minsk = new Stack<int>();
        }

        private Stack<int> stack, minsk;

        public int GetMin()
        {
            return minsk.Peek();
        }

        public void Pop()
        {
            minsk.Pop();
            stack.Pop();
        }

        public void Push(int x)
        {
            stack.Push(x);
            if (minsk.Count == 0)
                minsk.Push(x);
            else
                minsk.Push(Math.Min(x, minsk.Peek()));
        }

        public int Top()
        {
            return stack.Peek();
        }
    }
}
