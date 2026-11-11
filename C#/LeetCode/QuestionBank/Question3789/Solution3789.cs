using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3789
{
    public class Solution3789 : Interface3789
    {
        /// <summary>
        /// 贪心，分类讨论
        /// </summary>
        /// <param name="cost1"></param>
        /// <param name="cost2"></param>
        /// <param name="costBoth"></param>
        /// <param name="need1"></param>
        /// <param name="need2"></param>
        /// <returns></returns>
        public long MinimumCost(int cost1, int cost2, int costBoth, int need1, int need2)
        {
            if (costBoth <= cost1 && costBoth <= cost2) return 1L * costBoth * Math.Max(need1, need2);
            if (costBoth >= cost1 + cost2) return 1L * cost1 * need1 + 1L * cost2 * need2;

            long result = 0;
            int needBoth = Math.Min(need1, need2);
            result += 1L * costBoth * needBoth;
            if ((need1 -= needBoth) > 0)
            {
                result += 1L * (costBoth <= cost1 ? costBoth : cost1) * need1;
            }
            else if ((need2 -= needBoth) > 0)
            {
                result += 1L * (costBoth <= cost2 ? costBoth : cost2) * need2;
            }

            return result;
        }
    }
}
