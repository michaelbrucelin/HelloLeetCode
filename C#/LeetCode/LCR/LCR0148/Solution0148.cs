using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0148
{
    public class Solution0148 : Interface0148
    {
        /// <summary>
        /// 栈模拟
        /// </summary>
        /// <param name="putIn"></param>
        /// <param name="takeOut"></param>
        /// <returns></returns>
        public bool ValidateBookSequences(int[] putIn, int[] takeOut)
        {
            if (putIn.Length < 3) return true;

            int p1 = 0, p2 = 0, len = putIn.Length;
            Stack<int> stack = new Stack<int>();
            while (p1 < len)
            {
                while (stack.Count > 0 && stack.Peek() == takeOut[p2]) { stack.Pop(); p2++; }
                stack.Push(putIn[p1++]);
            }
            while (stack.Count > 0 && stack.Peek() == takeOut[p2]) { stack.Pop(); p2++; }

            return stack.Count == 0;
        }
    }
}
