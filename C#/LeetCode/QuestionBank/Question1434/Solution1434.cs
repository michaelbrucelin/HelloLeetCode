using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1434
{
    public class Solution1434 : Interface1434
    {
        /// <summary>
        /// DP
        /// 
        /// 当前是错的，没写完，以后再写
        /// </summary>
        /// <param name="hats"></param>
        /// <returns></returns>
        public int NumberWays(IList<IList<int>> hats)
        {
            int n = 0, len = hats.Count;
            for (int i = 0; i < len; i++) n = Math.Max(n, hats[i].Max());
            int[,] dp = new int[len + 1, n + 1];
            const int MOD = (int)1e9 + 7;
            for (int i = 0, sum = 1, _sum; i < len; i++)
            {
                _sum = 0;
                foreach (int x in hats[i])
                {
                    dp[i + 1, x] = (sum - dp[i, x] + MOD) % MOD;
                    _sum = (_sum + dp[i + 1, x]) % MOD;
                }
                sum = _sum;
            }

            int result = 0;
            foreach (int x in hats[^1]) result = (result + dp[len, x]) % MOD;
            return result;
        }
    }
}
