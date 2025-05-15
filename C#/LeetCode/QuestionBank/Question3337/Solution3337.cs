using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3337
{
    public class Solution3337 : Interface3337
    {
        /// <summary>
        /// DP
        /// 记录每次变换后每个字母的数量，显然会TLE，先写出来再改为矩阵快速幂
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int LengthAfterTransformations(string s, int t, IList<int> nums)
        {
            const int MOD = (int)1e9 + 7;
            int[] dp = new int[26], _dp = new int[26];
            foreach (char c in s) dp[c - 'a']++;
            for (int _t = 0; _t < t; _t++)
            {
                Array.Fill(_dp, 0);


                Array.Copy(_dp, dp, 26);
            }

            int result = 0;
            for (int i = 0; i < 26; i++) result = (result + dp[i]) % MOD;
            return result;
        }
    }
}
