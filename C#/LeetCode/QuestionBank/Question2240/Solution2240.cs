using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2240
{
    public class Solution2240 : Interface2240
    {
        /// <summary>
        /// 枚举
        /// </summary>
        /// <param name="total"></param>
        /// <param name="cost1"></param>
        /// <param name="cost2"></param>
        /// <returns></returns>
        public long WaysToBuyPensPencils(int total, int cost1, int cost2)
        {
            if (cost1 < cost2) (cost1, cost2) = (cost2, cost1);  // 大驱动小
            long result = 0;
            total += cost1;
            while ((total -= cost1) > 0) result += total / cost2 + 1;
            if (total == 0) result++;

            return result;
        }
    }
}
