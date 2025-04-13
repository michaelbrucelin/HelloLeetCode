using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1475
{
    public class Solution1475_4 : Interface1475
    {
        /// <summary>
        /// 单调栈
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public int[] FinalPrices(int[] prices)
        {
            int len = prices.Length;
            int[] result = new int[len];
            Stack<int> stack = new Stack<int>();
            for (int i = len - 1, price = 0; i >= 0; i--)
            {
                price = prices[i];
                while (stack.Count > 0 && stack.Peek() > price) stack.Pop();
                if (stack.Count > 0) result[i] = price - stack.Peek(); else result[i] = price;
                stack.Push(price);
            }

            return result;
        }
    }
}
