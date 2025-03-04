using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1745
{
    public class Solution1745 : Interface1745
    {
        /// <summary>
        /// 预处理 + 枚举
        /// 预处理出全部的子回文串
        ///     长度为1的字串一定是回文串
        ///     长度为2的字串判断是否是回文串
        ///     长度 >2的字串如果是回文串：两端的字符相同 且 去掉两端的子串是回文串
        /// 枚举各种可能
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool CheckPartitioning(string s)
        {
            int n = s.Length;
            // 预处理出全部的子回文串
            bool[,] dp = new bool[n, n];
            for (int i = 0; i < n; i++) dp[i, i] = true;
            for (int i = 1; i < n; i++) dp[i - 1, i] = s[i - 1] == s[i];
            for (int l = 2; l < n; l++) for (int i = l; i < n; i++) dp[i - l, i] = s[i - l] == s[i] && dp[i - l + 1, i - 1];

            // 枚举
            for (int i = 0; i < n; i++) for (int j = i + 2; j < n; j++)
                {
                    if (dp[0, i] && dp[i + 1, j - 1] && dp[j, n - 1]) return true;
                }

            return false;
        }
    }
}
