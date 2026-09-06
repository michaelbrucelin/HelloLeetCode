using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0115
{
    public class Solution0115_2 : Interface0115
    {
        /// <summary>
        /// DP
        /// 以 s = babgbag, t = bag 为例
        /// 初始状态好判断，第一行记录s[0..i]出现了几个b，从第2行开始，前[0..r-1]为0，然后 dp[r,c] = dp[r,c-1] + (s[c]==t[r]?dp[r-1,c-1],0)
        /// 初始状态         |  填第1行          |  填第2行
        ///   b a b g b a g  |    b a b g b a g  |    b a b g b a g
        /// b 1 1 2 2 3 3 3  |  b 1 1 2 2 3 3 3  |  b 1 1 2 2 3 3 3
        /// a 0              |  a 0 1 1 1 1 4 4  |  a 0 1 1 1 1 4 4
        /// g 0 0            |  g 0 0            |  g 0 0 0 1 1 1 5
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public int NumDistinct(string s, string t)
        {
            if (s.Length < t.Length) return 0;
            if (s.Length == t.Length) return s == t ? 1 : 0;

            int rcnt = t.Length, ccnt = s.Length;
            int[,] dp = new int[rcnt, ccnt];
            if (s[0] == t[0]) dp[0, 0] = 1;
            for (int c = 1; c < ccnt; c++) dp[0, c] = dp[0, c - 1] + (s[c] == t[0] ? 1 : 0);
            for (int r = 1; r < rcnt; r++) for (int c = r; c < ccnt; c++) dp[r, c] = dp[r, c - 1] + (s[c] == t[r] ? dp[r - 1, c - 1] : 0);

            return dp[rcnt - 1, ccnt - 1];
        }
    }
}
