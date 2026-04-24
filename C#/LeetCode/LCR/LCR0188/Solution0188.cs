using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0188
{
    public class Solution0188 : Interface0188
    {
        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public int BestTiming(int[] prices)
        {
            if (prices.Length < 2) return 0;

            int result = 0, min = prices[0], len = prices.Length;
            for (int i = 1, price; i < len; i++)
            {
                price = prices[i];
                if (price < min) min = price; else result = Math.Max(result, price - min);
            }

            return result;
        }
    }
}
