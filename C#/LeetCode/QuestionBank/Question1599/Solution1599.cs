using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1599
{
    public class Solution1599 : Interface1599
    {
        public int MinOperationsMaxProfit(int[] customers, int boardingCost, int runningCost)
        {
            if ((boardingCost << 2) <= runningCost) return -1;

            int result = -1, max_profit = 0, profit = 0, queue = 0, len = customers.Length;
            for (int i = 0; i < len || queue > 0; i++)
            {
                if (i < len) queue += customers[i];
                if (queue >= 4)
                {
                    profit += (boardingCost << 2) - runningCost;
                    if (profit > max_profit) { max_profit = profit; result = i + 1; }
                    queue -= 4;
                }
                else
                {
                    profit += boardingCost * queue - runningCost;
                    if (profit > max_profit) { max_profit = profit; result = i + 1; }
                    queue = 0;
                }
            }

            return result;
        }
    }
}
