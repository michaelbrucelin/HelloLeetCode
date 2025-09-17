using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0091
{
    public class Solution0091 : Interface0091
    {
        /// <summary>
        /// DP
        /// F(N) 表示以 s[N] 结尾的结果数量，则 F(N+2)
        ///     F(N+2) = F(N+1) + F(N)
        ///              F(N+1)，s[N+2] != 0，独立一个字符
        ///              F(N)，s[N] !=0 && "s[N]s[N+1]" <= 26，与前面结合
        /// 
        /// 可使用滚动数组，这里数据量很小，没必要
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int NumDecodings(string s)
        {
            if (s[0] == '0') return 0;
            if (s.Length == 1) return 1;

            int len = s.Length;
            int[] dp = new int[len];
            dp[0] = 1;
            if (s[1] != '0') dp[1] = 1;
            if (int.Parse(s[..2]) < 27) dp[1]++;
            for (int i = 2; i < len; i++)
            {
                if (s[i] != '0') dp[i] = dp[i - 1];
                if (s[i - 1] != '0' && int.Parse(s[(i - 1)..(i + 1)]) < 27) dp[i] += dp[i - 2];
            }

            return dp[len - 1];
        }

        /// <summary>
        /// 逻辑同NumDecodings()，将int.Parse()改为直接运算试试
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int NumDecodings2(string s)
        {
            if (s[0] == '0') return 0;
            if (s.Length == 1) return 1;

            int len = s.Length;
            int[] dp = new int[len];
            dp[0] = 1;
            if (s[1] != '0') dp[1] = 1;
            if (int.Parse(s[..2]) < 27) dp[1]++;
            for (int i = 2; i < len; i++)
            {
                if (s[i] != '0') dp[i] = dp[i - 1];
                if (s[i - 1] != '0' && (s[i - 1] & 15) * 10 + (s[i] & 15) < 27) dp[i] += dp[i - 2];
            }

            return dp[len - 1];
        }
    }
}
