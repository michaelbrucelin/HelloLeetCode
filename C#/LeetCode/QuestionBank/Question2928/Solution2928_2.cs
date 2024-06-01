using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2928
{
    public class Solution2928_2 : Interface2928
    {
        /// <summary>
        /// 枚举 + 数学
        /// </summary>
        /// <param name="n"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public int DistributeCandies(int n, int limit)
        {
            int triple = limit * 3;
            if (n > triple) return 0;
            if (n == triple) return 1;

            int result = 0, twice = limit << 1;
            for (int i = Math.Max(n - twice, 0); i <= Math.Min(limit, n); i++)  // 第1个小朋友
            {
                result += Math.Min(n - i + 1, twice - (n - i) + 1);
            }

            return result;
        }
    }
}
