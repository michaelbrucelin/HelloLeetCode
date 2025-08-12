using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2787
{
    public class Solution2787_2 : Interface2787
    {
        /// <summary>
        /// DP
        /// 逻辑同Solution2787，只是将DFS+记搜改为了DP
        /// 
        /// 直觉上DP会变慢，因为DP会处理很多“无效”的状态
        /// </summary>
        /// <param name="n"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public int NumberOfWays(int n, int x)
        {
            List<int> list = new List<int>();
            if (x == 1)
            {
                for (int i = 1; i <= n; i++) list.Add(i);
            }
            else
            {
                for (int i = 1, j; i <= n; i++)
                {
                    j = (int)Math.Pow(i, x);
                    if (j <= n) list.Add(j); else break;
                }
            }

            const int MOD = (int)1e9 + 7;
            int len = list.Count;
            int[,] dp = new int[len + 1, n + 1];
            for (int i = len - 1; i >= 0; i--) for (int j = 1; j <= n; j++)
                {
                    if (j == list[i]) dp[i, j] = 1;
                    else dp[i, j] = j < list[i] ? dp[i + 1, j] : (dp[i + 1, j] + dp[i + 1, j - list[i]]) % MOD;
                }

            return dp[0, n];
        }

        /// <summary>
        /// 逻辑同NumberOfWays()，改为滚动数组
        /// </summary>
        /// <param name="n"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public int NumberOfWays2(int n, int x)
        {
            List<int> list = new List<int>();
            if (x == 1)
            {
                for (int i = 1; i <= n; i++) list.Add(i);
            }
            else
            {
                for (int i = 1, j; i <= n; i++)
                {
                    j = (int)Math.Pow(i, x);
                    if (j <= n) list.Add(j); else break;
                }
            }

            const int MOD = (int)1e9 + 7;
            int len = list.Count;
            int[] dp = new int[n + 1], _dp = new int[n + 1];
            for (int i = len - 1; i >= 0; i--)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (j == list[i]) _dp[j] = 1;
                    else _dp[j] = j < list[i] ? dp[j] : (dp[j] + dp[j - list[i]]) % MOD;
                }
                Array.Copy(_dp, dp, n + 1);
            }

            return dp[n];
        }
    }
}
