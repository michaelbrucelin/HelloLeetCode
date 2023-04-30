using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0338
{
    public class Solution0338_2 : Interface0338
    {
        /// <summary>
        /// 分奇数和偶数：
        ///     偶数的二进制1个数超级简单，因为偶数是相当于被某个更小的数乘2，乘2怎么来的？在二进制运算中，就是左移一位，也就是在低位多加1个0，
        ///         那样就说明dp[i] = dp[i/2]
        ///     奇数稍微难想到一点，奇数由不大于该数的偶数+1得到，偶数+1在二进制位上会发生什么？会在低位多加1个1，
        ///         那样就说明dp[i] = dp[i-1] + 1，当然也可以写成dp[i] = dp[i/2] + 1
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int[] CountBits(int n)
        {
            int[] result = new int[n + 1]; result[0] = 0;
            for (int i = 1; i <= n; i++)
            {
                result[i] = result[i >> 1] + (i & 1);
            }

            return result;
        }
    }
}
