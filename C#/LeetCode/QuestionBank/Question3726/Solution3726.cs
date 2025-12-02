using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3726
{
    public class Solution3726 : Interface3726
    {
        public long RemoveZeros(long n)
        {
            long result = 0, digit;
            Stack<long> stack = new Stack<long>();
            while (n > 0)
            {
                digit = n % 10;
                if (digit > 0) stack.Push(digit);
                n /= 10;
            }
            while (stack.Count > 0) result = result * 10 + stack.Pop();

            return result;
        }
    }
}
