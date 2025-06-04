using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2929
{
    public class Solution2929 : Interface2929
    {
        /// <summary>
        /// 数学
        /// 枚举第一个小朋友，分析余下两个小朋友
        /// </summary>
        /// <param name="n"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public long DistributeCandies(int n, int limit)
        {
            if (n > limit * 3) return 0;

            long result = 0;
            int _n, _limit = limit << 1, min1 = Math.Max(n - (limit << 1), 0), max1 = Math.Min(limit, n);
            for (int i = min1; i <= max1; i++)
            {
                _n = n - i;
                result += _n <= limit ? _n + 1 : _limit - _n + 1;
            }

            return result;
        }
    }
}
