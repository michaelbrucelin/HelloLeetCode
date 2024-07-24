using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3226
{
    public class Solution3226 : Interface3226
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MinChanges(int n, int k)
        {
            if (n < k) return -1;
            if (n == k) return 0;

            int times = 0;
            for (int i = 0; i < 32; i++) switch (((n >> i) & 1, (k >> i) & 1))
                {
                    case (1, 0): times++; break;
                    case (0, 1): return -1;
                }

            return times;
        }
    }
}
