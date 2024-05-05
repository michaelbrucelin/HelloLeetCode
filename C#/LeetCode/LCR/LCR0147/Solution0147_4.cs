using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0147
{
    public class Solution0147_4
    {
    }

    /// <summary>
    /// 单栈
    /// 逻辑与Solution0147_3相同，本质上仍然是一个栈，只是将值合并为值元组，进而合并为一个栈
    /// </summary>
    public class MinStack_4 : Interface0147
    {
        public MinStack_4()
        {
            stack = new Stack<(int val, int min)>();
            stack.Push((int.MaxValue, int.MaxValue));
        }

        private Stack<(int val, int min)> stack;

        public int GetMin()
        {
            return stack.Peek().min;
        }

        public void Pop()
        {
            stack.Pop();
        }

        public void Push(int x)
        {
            stack.Push((x, Math.Min(x, GetMin())));
        }

        public int Top()
        {
            return stack.Peek().val;
        }
    }
}
