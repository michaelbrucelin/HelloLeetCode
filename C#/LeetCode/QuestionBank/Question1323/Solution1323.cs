using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1323
{
    public class Solution1323 : Interface1323
    {
        public int Maximum69Number(int num)
        {
            Stack<int> stack = new Stack<int>();
            while (num > 0) { stack.Push(num % 10); num /= 10; }

            int result = 0, digit; bool flag = true;
            while (stack.Count > 0)
            {
                digit = stack.Pop();
                if (flag && digit == 6)
                {
                    result = result * 10 + 9; flag = false;
                }
                else
                {
                    result = result * 10 + digit;
                }
            }

            return result;
        }
    }
}
