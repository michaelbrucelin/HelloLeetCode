using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3502
{
    public class Solution3502 : Interface3502
    {
        /// <summary>
        /// 遍历
        /// 遍历找每个位置的前面的最小值
        /// </summary>
        /// <param name="cost"></param>
        /// <returns></returns>
        public int[] MinCosts(int[] cost)
        {
            int len = cost.Length;
            int[] result = new int[len];

            result[0] = cost[0];
            for (int i = 1; i < len; i++) result[i] = Math.Min(result[i - 1], cost[i]);

            return result;
        }
    }
}
