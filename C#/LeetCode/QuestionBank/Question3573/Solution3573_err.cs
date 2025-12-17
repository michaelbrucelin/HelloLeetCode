using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3573
{
    public class Solution3573_err : Interface3573
    {
        /// <summary>
        /// DP
        /// F(N)表示数组的前N项的最大利润，并记录交易的次数，则F(N+1)
        ///     不用，F(N)
        ///     用，向前查找每个值，MAX(F(X-1) + ABS(Prices(N+1)-Prices(X)))
        /// 时间复杂度：O(N^2)
        /// 
        /// 错的，参考测试用例03
        /// </summary>
        /// <param name="prices"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public long MaximumProfit(int[] prices, int k)
        {
            int len = prices.Length;
            if (k == 1)
            {
                long min = prices[0], max = prices[0];
                for (int i = 1; i < len; i++) { min = Math.Min(min, prices[i]); max = Math.Max(max, prices[i]); }
                return max - min;
            }

            long[] dpv = new long[len + 1];
            int[] dpk = new int[len + 1];
            long diff;
            for (int i = 0; i < len; i++)
            {
                dpv[i + 1] = dpv[i]; dpk[i + 1] = dpk[i];
                diff = 0;
                for (int j = i - 1; j >= 0; j--) if (dpk[j] < k)
                    {
                        diff = Math.Max(diff, Math.Abs(0L + prices[i] - prices[j]) + dpv[j]);
                        if (diff > dpv[i + 1]) { dpv[i + 1] = diff; dpk[i + 1] = dpk[j] + 1; }
                    }
            }

            return dpv[len];
        }
    }
}
