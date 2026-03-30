using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2262
{
    public class Solution2262 : Interface2262
    {
        /// <summary>
        /// DP
        /// F(N,0)表示s[0..N]的结果，F(N,1)表示以s[N]结尾的结果，这样就可以推到F(N+1,0)与F(N+1,1)了
        /// 记录每个字符最后出现的位置，方便计算F(N+1,1)
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public long AppealSum(string s)
        {
            int len = s.Length;
            int[] pos = new int[26];
            Array.Fill(pos, -1); pos[s[0] - 'a'] = 0;
            long[] dp1 = new long[len], dp2 = new long[len];
            dp1[0] = dp2[0] = 1;
            for (int i = 1, j; i < len; i++)
            {
                j = s[i] - 'a';
                dp2[i] = dp2[i - 1] + i - pos[j];
                pos[j] = i;
                dp1[i] = dp1[i - 1] + dp2[i];
            }

            return dp1[len - 1];
        }

        /// <summary>
        /// 逻辑同AppealSum()，将数组改为变量
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public long AppealSum2(string s)
        {
            int len = s.Length;
            int[] pos = new int[26];
            Array.Fill(pos, -1); pos[s[0] - 'a'] = 0;
            long dp1 = 1, dp2 = 1;
            for (int i = 1, j; i < len; i++)
            {
                j = s[i] - 'a';
                dp2 = dp2 + i - pos[j];
                pos[j] = i;
                dp1 = dp1 + dp2;
            }

            return dp1;
        }
    }
}
