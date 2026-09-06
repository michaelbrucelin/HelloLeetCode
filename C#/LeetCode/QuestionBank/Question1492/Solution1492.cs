using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1492
{
    public class Solution1492 : Interface1492
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int KthFactor(int n, int k)
        {
            if (k == 1) return 1;
            if (n == 1) return -1;

            Stack<int> stack = new Stack<int>();
            int x = 1, y = n, cnt = 1;
            stack.Push(n);
            while (++x < y)
            {
                if (n % x != 0) continue;
                y = n / x;
                if (++cnt == k) return x;
                if (y != x) stack.Push(y);
            }
            if (stack.Count < k - cnt) return -1;
            for (int i = k - cnt - 1; i > 0; i--) stack.Pop();

            return stack.Pop();
        }
    }
}
