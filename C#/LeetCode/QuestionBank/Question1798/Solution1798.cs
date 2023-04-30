using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1798
{
    public class Solution1798 : Interface1798
    {
        /// <summary>
        /// DP
        /// 1. 数组排序
        /// 2. 如果前i个元素构成了[0, n]，那么第i+1个元素k只要满足k<=n+1即可，构造出来的新的[0, n+k]
        /// </summary>
        /// <param name="coins"></param>
        /// <returns></returns>
        public int GetMaximumConsecutive(int[] coins)
        {
            Array.Sort(coins);
            int result = 0;
            for (int i = 0; i < coins.Length; i++)
            {
                if (coins[i] > result + 1) break;
                result += coins[i];
            }

            return result + 1;
        }
    }
}
