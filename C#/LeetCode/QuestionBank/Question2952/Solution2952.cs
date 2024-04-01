using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2952
{
    public class Solution2952 : Interface2952
    {
        /// <summary>
        /// 排序 + 贪心
        /// 贪心是类二进制的思想，就是如果当前最大可以组合成N，那么下一个补充的就是N+1
        /// 例如：[1,4,10,5,7,19], 先排序 [1,4,5,7,10,19]
        ///     1. 有 1，最大组成 1
        ///     2. 下一个元素是4，1+1  <  4，补 1+1，最大组成 3
        ///     3. 下一个元素是4，3+1  >= 4，最大组成 3+4=7
        ///     4. 下一个元素是5，7+1  >= 5，最大组成 7+5=12
        ///     5. 下一个元素是7，12+1 >= 7，最大组成 12+7=19
        /// </summary>
        /// <param name="coins"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int MinimumAddedCoins(int[] coins, int target)
        {
            Array.Sort(coins);
            int result = 0, ptr = 0, reach = 0, len = coins.Length;
            while (ptr < len)
            {
                while (reach < coins[ptr] - 1)
                {
                    reach = ((reach + 1) << 1) - 1; result++;
                    if (reach >= target) return result;
                }
                reach += coins[ptr++];
                if (reach >= target) return result;
            }
            while (reach < target) { reach = (reach << 1) + 1; result++; }

            return result;
        }
    }
}
