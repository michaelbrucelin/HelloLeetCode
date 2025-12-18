using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3652
{
    public class Solution3652 : Interface3652
    {
        /// <summary>
        /// 滑动窗口
        /// </summary>
        /// <param name="prices"></param>
        /// <param name="strategy"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public long MaxProfit(int[] prices, int[] strategy, int k)
        {
            long result = 0, _result; int len = prices.Length;
            k >>= 1;
            for (int i = 0; i < len; i++) result += prices[i] * strategy[i];
            _result = result;
            for (int i1 = 0, i2 = k; i1 < k; i1++, i2++) _result += -prices[i1] * strategy[i1] + prices[i2] * (1 - strategy[i2]);
            result = Math.Max(result, _result);
            for (int i1 = 0, i2 = k, i3 = k << 1; i3 < len; i1++, i2++, i3++)
            {
                _result += prices[i1] * strategy[i1] - prices[i2] + prices[i3] * (1 - strategy[i3]);
                result = Math.Max(result, _result);
            }

            return result;
        }
    }
}
