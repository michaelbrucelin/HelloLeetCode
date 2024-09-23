using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1014
{
    public class Solution1014 : Interface1014
    {
        /// <summary>
        /// 维护区间最大值
        /// xi与xj的结果是xi+i + xj-j，所以以xj为最大值的和，需要取xi+i的最大值
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public int MaxScoreSightseeingPair(int[] values)
        {
            int result = values[0] + values[1] - 1, maxxi = values[0], len = values.Length;
            for (int i = 2; i < len; i++)
            {
                maxxi = Math.Max(maxxi, values[i - 1] + i - 1);
                result = Math.Max(result, maxxi + values[i] - i);
            }

            return result;
        }
    }
}
