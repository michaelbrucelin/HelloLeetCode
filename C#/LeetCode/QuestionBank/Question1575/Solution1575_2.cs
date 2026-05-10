using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1575
{
    public class Solution1575_2 : Interface1575
    {
        /// <summary>
        /// DP
        /// </summary>
        /// <param name="locations"></param>
        /// <param name="start"></param>
        /// <param name="finish"></param>
        /// <param name="fuel"></param>
        /// <returns></returns>
        public int CountRoutes(int[] locations, int start, int finish, int fuel)
        {
            int len = locations.Length;
            const int MOD = (int)1e9 + 7;
            int[,] dp = new int[len, fuel + 1];
            // for (int i = 0; i < len; i++) for (int j = 0; j <= fuel; j++) dp[i, j] = -1;
            dp[finish, 0] = 1;
            for (int f = 1, _f; f <= fuel; f++) for (int i = 0; i < len; i++)
                {
                    dp[i, f] = i == finish ? 1 : 0;
                    for (int j = 0; j < len; j++) if (j != i && (_f = Math.Abs(locations[j] - locations[i])) <= f)
                        {
                            dp[i, f] += dp[j, f - _f];
                            dp[i, f] %= MOD;
                        }
                }

            return dp[start, fuel];
        }
    }
}
