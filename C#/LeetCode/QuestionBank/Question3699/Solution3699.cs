using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3699
{
    public class Solution3699 : Interface3699
    {
        /// <summary>
        /// DP
        /// 逻辑没问题，tle，参考测试用例03
        /// </summary>
        /// <param name="n"></param>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public int ZigZagArrays(int n, int l, int r)
        {
            const int MOD = (int)1e9 + 7;
            r -= l; l = 0;
            int[,,] dp = new int[n, r + 1, 2];                           // dp[,,0] asc dp[,,1] desc
            for (int i = 0; i <= r; i++) dp[0, i, 0] = dp[0, i, 1] = 1;
            for (int i = 1; i < n; i++) for (int j = 0; j <= r; j++)
                {
                    for (int k = 0; k < j; k++) dp[i, j, 0] = (dp[i, j, 0] + dp[i - 1, k, 1]) % MOD;
                    for (int k = j + 1; k <= r; k++) dp[i, j, 1] = (dp[i, j, 1] + dp[i - 1, k, 0]) % MOD;
                }

            long result = 0;
            for (int i = 0; i <= r; i++) result = (result + dp[n - 1, i, 0] + dp[n - 1, i, 1]) % MOD;
            return (int)result;
        }

        /// <summary>
        /// 逻辑同ZigZagArrays()，取消第3层循环
        /// </summary>
        /// <param name="n"></param>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public int ZigZagArrays2(int n, int l, int r)
        {
            const int MOD = (int)1e9 + 7;
            r -= l; l = 0;
            int[,,] dp = new int[n, r + 1, 2];                           // dp[,,0] asc dp[,,1] desc
            for (int i = 0; i <= r; i++) dp[0, i, 0] = dp[0, i, 1] = 1;
            for (int i = 1; i < n; i++)
            {
                dp[i, 0, 0] = dp[i, r, 1] = 0;
                for (int j = 1, k = r - 1; j <= r; j++, k--)
                {
                    dp[i, j, 0] = (dp[i, j - 1, 0] + dp[i - 1, j - 1, 1]) % MOD;
                    dp[i, k, 1] = (dp[i, k + 1, 1] + dp[i - 1, k + 1, 0]) % MOD;
                }
            }

            long result = 0;
            for (int i = 0; i <= r; i++) result = (result + dp[n - 1, i, 0] + dp[n - 1, i, 1]) % MOD;
            return (int)result;
        }

        /// <summary>
        /// 逻辑同ZigZagArrays2()，改为锯齿数组试一下
        /// </summary>
        /// <param name="n"></param>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public int ZigZagArrays3(int n, int l, int r)
        {
            const int MOD = (int)1e9 + 7;
            r -= l; l = 0;
            int[][][] dp = new int[n][][];                           // dp[,,0] asc dp[,,1] desc
            for (int i = 0; i < n; i++)
            {
                dp[i] = new int[r + 1][];
                for (int j = 0; j <= r; j++) dp[i][j] = new int[2];
            }
            for (int i = 0; i <= r; i++) dp[0][i][0] = dp[0][i][1] = 1;
            for (int i = 1; i < n; i++)
            {
                dp[i][0][0] = dp[i][r][1] = 0;
                for (int j = 1, k = r - 1; j <= r; j++, k--)
                {
                    dp[i][j][0] = (dp[i][j - 1][0] + dp[i - 1][j - 1][1]) % MOD;
                    dp[i][k][1] = (dp[i][k + 1][1] + dp[i - 1][k + 1][0]) % MOD;
                }
            }

            long result = 0;
            for (int i = 0; i <= r; i++) result = (result + dp[n - 1][i][0] + dp[n - 1][i][1]) % MOD;
            return (int)result;
        }
    }
}
