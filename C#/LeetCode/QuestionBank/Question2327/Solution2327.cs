using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2327
{
    public class Solution2327 : Interface2327
    {
        /// <summary>
        /// DP
        /// 记录知道秘密1天，2天，...forget-1天的人数
        /// n = 6, delay = 2, forget = 4
        ///    0   1   2   3   4
        /// 1  0   1A  0   0   0
        /// 2  0   0   1A  0   0
        /// 3  0   1B  0   1A  0
        /// 4  0   1C  1B  0   1A
        /// 5  0   1D  1C  1B  0
        /// 6  0   2EF 1D  1C  1B
        /// </summary>
        /// <param name="n"></param>
        /// <param name="delay"></param>
        /// <param name="forget"></param>
        /// <returns></returns>
        public int PeopleAwareOfSecret(int n, int delay, int forget)
        {
            const int MOD = (int)1e9 + 7;
            int[] dp = new int[forget + 1];
            dp[1] = 1;
            while (--n > 0)
            {
                dp[0] = 0;
                for (int i = forget; i > delay; i--)
                {
                    dp[i] = dp[i - 1];
                    dp[0] = (dp[0] + dp[i - 1]) % MOD;
                }
                for (int i = delay; i > 0; i--) dp[i] = dp[i - 1];
            }

            int result = dp[1];
            for (int i = 2; i <= forget; i++) result = (result + dp[i]) % MOD;
            return result;
        }
    }
}
