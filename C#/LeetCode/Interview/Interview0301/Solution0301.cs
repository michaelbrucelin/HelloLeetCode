using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview0301
{
    public class Solution0301
    {
    }

    /// <summary>
    /// 可以使用一个3维数组，但是感觉有悖题目的本意，这里使用一维数组来实现
    /// </summary>
    public class TripleInOne : Interface0301
    {
        public TripleInOne(int stackSize)
        {
            stack = new int[stackSize * 3];
            ptrs = new int[] { -1, stackSize - 1, (stackSize << 1) - 1 };
            size = stackSize;
        }

        private int[] stack;
        private int[] ptrs;
        private int size;

        public bool IsEmpty(int stackNum)
        {
            return ptrs[stackNum] == size * stackNum - 1;
        }

        public int Peek(int stackNum)
        {
            if (IsEmpty(stackNum)) return -1;
            return stack[ptrs[stackNum]];
        }

        public int Pop(int stackNum)
        {
            if (IsEmpty(stackNum)) return -1;
            return stack[ptrs[stackNum]--];
        }

        public void Push(int stackNum, int value)
        {
            if (ptrs[stackNum] == size * (stackNum + 1) - 1) return;
            stack[++ptrs[stackNum]] = value;
        }
    }
}
