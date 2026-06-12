using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3700
{
    public class Solution3700 : Interface3700
    {
        /// <summary>
        /// DP
        /// 必然会TLE，先写出了再说，提交没等到TLE，先等到了MLE，参考测试用例03
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
        /// 逻辑同ZigZagArrays()，改为滚动数组
        /// 
        /// 意料之中的TLE，参考测试用例04
        /// </summary>
        /// <param name="n"></param>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public int ZigZagArrays(int n, int l, int r)
        {
            const int MOD = (int)1e9 + 7;
            r -= l; l = 0;
            int[] dp0 = new int[r + 1], dp1 = new int[r + 1], _dp0 = new int[r + 1], _dp1 = new int[r + 1];  // dp0 asc dp1 desc
            for (int i = 0; i <= r; i++) dp0[i] = dp1[i] = 1;
            for (int i = 1; i < n; i++)
            {
                _dp0[0] = _dp1[r] = 0;
                for (int j = 1, k = r - 1; j <= r; j++, k--)
                {
                    _dp0[j] = (_dp0[j - 1] + dp1[j - 1]) % MOD;
                    _dp1[k] = (_dp1[k + 1] + dp0[k + 1]) % MOD;
                }
                Array.Copy(_dp0, dp0, r + 1);
                Array.Copy(_dp1, dp1, r + 1);
            }

            long result = 0;
            for (int i = 0; i <= r; i++) result = (result + dp0[i] + dp1[i]) % MOD;
            return (int)result;
        }
    }
}
