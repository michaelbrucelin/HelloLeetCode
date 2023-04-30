using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1475
{
    public class Solution1475_3 : Interface1475
    {
        public int[] FinalPrices(int[] prices)
        {
            int len = prices.Length;
            int[] result = new int[len];
            Stack<int> stack = new Stack<int>(); stack.Push(0);
            for (int i = len - 1; i >= 0; i--)
            {
                if (prices[i] >= stack.Peek())
                {
                    result[i] = prices[i] - stack.Peek(); stack.Push(prices[i]);
                }
                else
                {
                    while (stack.Peek() > prices[i]) stack.Pop();
                    result[i] = prices[i] - stack.Peek(); stack.Push(prices[i]);
                }
            }

            return result;
        }
    }
}
