using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1009
{
    public class Solution1009 : Interface1009
    {
        public int BitwiseComplement(int n)
        {
            if (n == 0) return 1;

            Stack<int> stack = new Stack<int>();
            while (n > 0)
            {
                stack.Push(1 - (n & 1));
                n >>= 1;
            }

            int result = 0;
            while (stack.Count > 0)
            {
                result = result * 2 + stack.Pop();
            }

            return result;
        }
    }
}
