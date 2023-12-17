using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2706
{
    public class Solution2706 : Interface2706
    {
        public int BuyChoco(int[] prices, int money)
        {
            int min1 = int.MaxValue, min2 = int.MaxValue;
            for (int i = 0, price; i < prices.Length; i++)
            {
                price = prices[i];
                if (price < min1)
                {
                    min2 = min1; min1 = price;
                }
                else if (price < min2)
                {
                    min2 = price;
                }
            }

            return min1 + min2 > money ? money : money - min1 - min2;
        }
    }
}
