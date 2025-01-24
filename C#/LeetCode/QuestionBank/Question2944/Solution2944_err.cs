using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2944
{
    public class Solution2944_err : Interface2944
    {
        /// <summary>
        /// DP
        /// 1. 第一个水果必须买
        /// 2. 买水果只会影响后面，不会影响前面
        /// 3. 每个水果最多只需要买一次
        /// 下面以[26, 18, 6, 12, 49, 7, 45, 45]为例
        ///  1      2      3      4      5       6       7       8
        ///  26     18     6      12     49      7       45      45
        /// (26,2) (26,2) (44,4) (32,6) (32,6)  (32,6)  (39,14) (39,16)  (不买当前水果的最小价钱，不买当前水果买到的最远距离)
        /// (26,2) (44,4) (32,6) (44,8) (81,10) (39,12) (77,14) (84,16)  (  买当前水果的最小价钱，  买当前水果买到的最远距离)
        /// 
        /// 算法是错误的，参考这个例子，而且把问题想复杂了，所以不再改进，重写，参考Solution2944
        /// 再以[1,37,19,38,11,42,18,33,6,37,15,48,23,12,41,18,27,32]为例
        /// +          +           +                       +
        /// 1    2     3     4     5     6     7     8     9     10    11    12    13    14    15    16    17    18
        /// 1    37    19    38    11    42    18    33    6     37    15    48    23    12    41    18    27    32
        /// 1,2  1,2   38,4  20,6  20,6  20,6  31,10  注意这里是31,10，而不是62,12
        /// 1,2  38,4  20,6  58,8  31,10 62,12
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public int MinimumCoins(int[] prices)
        {
            int n = prices.Length;
            int[,] dp = new int[n, 4];
            dp[0, 0] = dp[0, 2] = prices[0]; dp[0, 1] = dp[0, 3] = 2;
            for (int i = 1; i < n; i++)
            {
                if (dp[i - 1, 1] > i)
                {
                    switch (dp[i - 1, 0] - dp[i - 1, 2])
                    {
                        case < 0:
                            dp[i, 0] = dp[i - 1, 0]; dp[i, 1] = dp[i - 1, 1];
                            break;
                        case > 0:
                            dp[i, 0] = dp[i - 1, 2]; dp[i, 1] = dp[i - 1, 3];
                            break;
                        default:
                            dp[i, 0] = dp[i - 1, 0]; dp[i, 1] = Math.Max(dp[i - 1, 1], dp[i - 1, 3]);
                            break;
                    }
                }
                else
                {
                    dp[i, 0] = dp[i - 1, 2]; dp[i, 1] = dp[i - 1, 3];
                }
                dp[i, 2] = prices[i] + Math.Min(dp[i - 1, 0], dp[i - 1, 2]); dp[i, 3] = (i + 1) << 1;
            }

            return Math.Min(dp[n - 1, 0], dp[n - 1, 2]);
        }
    }
}
