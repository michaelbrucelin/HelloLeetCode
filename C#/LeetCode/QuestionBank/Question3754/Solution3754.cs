using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3754
{
    public class Solution3754 : Interface3754
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public long SumAndMultiply(int n)
        {
            Stack<int> stack = new Stack<int>();
            while (n > 0) { stack.Push(n % 10); n /= 10; }

            int d, _n = 0, sum = 0;
            while (stack.Count > 0) if ((d = stack.Pop()) != 0)
                {
                    _n = _n * 10 + d;
                    sum += d;
                }

            return 1L * _n * sum;
        }
    }
}
