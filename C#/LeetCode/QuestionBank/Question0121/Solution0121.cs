using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0121
{
    public class Solution0121 : Interface0121
    {
        public int MaxProfit(int[] prices)
        {
            int result = 0, buy = prices[0];
            for (int i = 1; i < prices.Length; i++)
            {
                if (prices[i] >= buy)
                    result = Math.Max(result, prices[i] - buy);
                else
                    buy = prices[i];
            }

            return result;
        }
    }
}
