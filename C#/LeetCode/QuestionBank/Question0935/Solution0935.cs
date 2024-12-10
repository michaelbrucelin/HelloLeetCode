using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0935
{
    public class Solution0935 : Interface0935
    {
        private static readonly int[][] map = { [4, 6], [6, 8], [7, 9], [4, 8], [0, 3, 9], [], [0, 1, 7], [2, 6], [1, 3], [2, 4] };

        /// <summary>
        /// DP，递推
        /// dp[i]中记录以i结尾的可能的数量
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int KnightDialer(int n)
        {
            if (n == 1) return 10;

            int[] dp = [1, 1, 1, 1, 1, 1, 1, 1, 1, 1], _dp = new int[10];
            const int MOD = (int)1e9 + 7;
            for (int i = 1; i < n; i++)
            {
                Array.Fill(_dp, 0);
                for (int j = 0; j < 10; j++) foreach (int k in map[j])
                    {
                        _dp[k] = (_dp[k] + dp[j]) % MOD;
                    }
                Array.Copy(_dp, dp, 10);
            }

            int result = 0;
            for (int i = 0; i < 10; i++) result = (result + dp[i]) % MOD;
            return result;
        }
    }
}
