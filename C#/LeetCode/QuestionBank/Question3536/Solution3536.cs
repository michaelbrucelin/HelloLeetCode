using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3536
{
    public class Solution3536 : Interface3536
    {
        /// <summary>
        /// 贪心
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int MaxProduct(int n)
        {
            int[] freq = new int[10];
            while (n > 0) { freq[n % 10]++; n /= 10; }

            int x = 0, y = 0, p = 9;
            while (p > 0)
            {
                if (freq[p] > 0) { x = p; freq[p]--; break; } else p--;
            }
            while (p > 0)
            {
                if (freq[p] > 0) { y = p; break; } else p--;
            }

            return x * y;
        }
    }
}
