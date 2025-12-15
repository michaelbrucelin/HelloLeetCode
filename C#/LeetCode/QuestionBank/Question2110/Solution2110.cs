using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2110
{
    public class Solution2110 : Interface2110
    {
        /// <summary>
        /// 排列组合
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public long GetDescentPeriods(int[] prices)
        {
            long result = 0; int cnt = 1, len = prices.Length;
            for (int i = 1; i < len; i++)
            {
                if (prices[i] + 1 == prices[i - 1])
                {
                    cnt++;
                }
                else
                {
                    result += 1L * cnt * (cnt + 1) >> 1;
                    cnt = 1;
                }
            }
            result += 1L * cnt * (cnt + 1) >> 1;

            return result;
        }

        /// <summary>
        /// 逻辑同GetDescentPeriods()，改为“加法”
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public long GetDescentPeriods2(int[] prices)
        {
            long result = 1; int cnt = 1, len = prices.Length;
            for (int i = 1; i < len; i++)
            {
                if (prices[i] + 1 == prices[i - 1])
                {
                    result += ++cnt;
                }
                else
                {
                    result += (cnt = 1);
                }
            }

            return result;
        }
    }
}
