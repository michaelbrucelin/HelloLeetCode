using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2472
{
    public class Solution2472 : Interface2472
    {
        /// <summary>
        /// DP
        /// F(N) 表示 s[0..N] 的结果，F(N+1) = 不用 s[N+1]，F(N)
        ///                                    使用 s[N+1]，F(X) + 1
        /// 问题是怎样快速的找到 F(X)，这里先暴力找，大概率会TLE
        /// 
        /// 本以为会TLE，竟然通过了... ...
        /// </summary>
        /// <param name="s"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MaxPalindromes(string s, int k)
        {
            if (k == 1) return s.Length;
            if (k == s.Length) return check(s, 0, s.Length - 1) ? 1 : 0;

            int len = s.Length;
            int[] dp = new int[len];
            for (int i = k - 1; i < len; i++)
            {
                dp[i] = dp[i - 1];                    // 不使用s[i]
                for (int j = i - k + 1; j >= 0; j--)  // 使用s[i]
                {
                    if (dp[i] > 0 && j > 0 && dp[i] >= dp[j - 1] + 1) break;
                    if (check(s, j, i))
                    {
                        dp[i] = j > 0 ? dp[j - 1] + 1 : 1;
                        break;
                    }
                }
            }

            return dp[len - 1];

            static bool check(string s, int l, int r)
            {
                while (l < r)
                {
                    if (s[l] != s[r]) return false;
                    l++; r--;
                }
                return true;
            }
        }
    }
}
