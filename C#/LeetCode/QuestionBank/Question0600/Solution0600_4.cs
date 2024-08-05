using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0600
{
    public class Solution0600_4 : Interface0600
    {
        /// <summary>
        /// DP
        /// 逻辑同Solution0600，自底向上DP
        /// 假定F(N,0)表示n的后N位第1位是0的结果，F(N,1)表示n的后N位第1位是1的结果
        /// 那么后N+1位：
        ///     如果第N+1位是0：F(N+1,0) = F(N,0) + F(N,1), F(N+1,1) = 0
        ///     如果第N+1位是1：F(N+1,0) = N位的所有可能,   F(N+1,1) = F(N,0)
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int FindIntegers(int n)
        {
            if (n < 3) return n + 1;

            int[] dial = new int[32];
            dial[0] = 1; dial[1] = 2; dial[2] = 3;
            for (int i = 3; i < 32; i++) dial[i] = dial[i - 1] + dial[i - 2];

            List<int> bits = new List<int>();
            while (n > 0) { bits.Add(n & 1); n >>= 1; }

            int len = bits.Count;
            int[,] dp = new int[len + 1, 2]; dp[0, 0] = 1; dp[0, 1] = 0;
            for (int i = 0; i < len; i++)
            {
                if (bits[i] == 0)
                {
                    dp[i + 1, 0] = dp[i, 0] + dp[i, 1]; dp[i + 1, 1] = 0;
                }
                else
                {
                    dp[i + 1, 0] = dial[i]; dp[i + 1, 1] = dp[i, 0];
                }
            }

            return dp[len, 0] + dp[len, 1];
        }
    }
}
