using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2483
{
    public class Solution2483 : Interface2483
    {
        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="customers"></param>
        /// <returns></returns>
        public int BestClosingTime(string customers)
        {
            int cost = 0, len = customers.Length;
            for (int i = 0; i < len; i++) cost += customers[i] & 1;  // Y->1, N->0

            int result = 0, min_cost = cost;
            for (int i = 0; i < len; i++)
            {
                cost -= ((customers[i] & 1) << 1) - 1;               // Y->1, N->-1
                if (cost < min_cost)
                {
                    result = i + 1; min_cost = cost;
                }
            }

            return result;
        }
    }
}
