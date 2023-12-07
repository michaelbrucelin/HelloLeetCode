using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2928
{
    public class Solution2928 : Interface2928
    {
        /// <summary>
        /// 暴力枚举
        /// </summary>
        /// <param name="n"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public int DistributeCandies(int n, int limit)
        {
            int triple = limit * 3;
            if (n > triple) return 0;
            if (n == triple) return 1;

            int result = 0;
            for (int i = 0; i <= limit; i++) for (int j = 0; j <= limit; j++) for (int k = 0; k <= limit; k++)
                    {
                        if (i + j + k == n) result++;
                    }

            return result;
        }

        /// <summary>
        /// 暴力枚举，剪枝优化
        /// </summary>
        /// <param name="n"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public int DistributeCandies2(int n, int limit)
        {
            int triple = limit * 3;
            if (n > triple) return 0;
            if (n == triple) return 1;

            int result = 0;
            for (int i = Math.Max(n - (limit << 1), 0); i <= limit; i++) for (int j = Math.Max(n - i - limit, 0); j <= limit; j++)
                {
                    if (n - i - j >= 0) result++;
                }

            return result;
        }
    }
}
