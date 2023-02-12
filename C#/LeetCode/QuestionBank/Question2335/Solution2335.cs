using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2335
{
    public class Solution2335 : Interface2335
    {
        /// <summary>
        /// 贪心
        /// 每次将两个较大的数字减一即可。
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public int FillCups(int[] amount)
        {
            int result = 0;
            Array.Sort(amount);
            while (amount[2] > 0)
            {
                if (amount[1] > 0)
                {
                    amount[1]--; amount[2]--;
                }
                else
                {
                    amount[2]--;
                }
                result++; Array.Sort(amount);
            }

            return result;
        }

        /// <summary>
        /// 递归
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public int FillCups2(int[] amount)
        {
            Array.Sort(amount);
            if (amount[2] == 0) return 0;

            if (amount[1] > 0)
            {
                amount[1]--; amount[2]--;
            }
            else
            {
                amount[2]--;
            }
            return FillCups2(amount) + 1;
        }
    }
}
