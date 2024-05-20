using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1542
{
    public class Solution1542_2 : Interface1542
    {
        /// <summary>
        /// DP
        /// 本质上没比Solution1542更节省时间，依然O(10n^2)
        /// 1. s[0..0]的结果为1
        /// 2. 如果s[0..n]的结果为N
        /// 3. s[0..n+1]的结果
        ///     不包含s[n+1]，结果为N
        ///     包含s[n+1]，结果贪心的查找（需要预处理与Solution1542一样的类前缀和的数据）
        /// 
        /// 逻辑没问题，依然TLE，参考测试用例05
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int LongestAwesome(string s)
        {
            if (s.Length < 2) return 1;

            int len = s.Length;
            int[,] freq = new int[len + 1, 10];
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < 10; j++) freq[i + 1, j] = freq[i, j];
                freq[i + 1, s[i] & 15]++;
            }

            int dp = 1, flag;
            for (int i = 1, j; i < len; i++)
            {
                for (j = 0; j <= i; j++)
                {
                    flag = 0;
                    for (int k = 0; k < 10; k++) if (((freq[i + 1, k] - freq[j, k]) & 1) != 0) flag++;
                    if (flag < 2) break;
                }
                dp = Math.Max(dp, i - j + 1);
            }

            return dp;
        }

        /// <summary>
        /// 逻辑同LongestAwesome()
        /// 只是将freq简化为int[]，用int表示0-9 10个数字的次数的奇偶性
        ///     1 表示奇数次，0表示偶数次
        /// 时间复杂度可降为LongestAwesome()的1/10，理论上依然TLE
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int LongestAwesome2(string s)
        {
            if (s.Length < 2) return 1;

            int len = s.Length;
            int[] freq = new int[len + 1];
            for (int i = 0; i < len; i++) freq[i + 1] = freq[i] ^ (1 << (s[i] & 15));


            int dp = 1;
            for (int i = 1, j; i < len; i++)
            {
                for (j = 0; j <= i; j++) if (BitCount(freq[i + 1] ^ freq[j]) < 2) break;
                dp = Math.Max(dp, i - j + 1);
            }

            return dp;
        }

        private static int BitCount(int u)
        {
            int result = 0;
            while (u > 0) { result++; u &= (u - 1); }

            return result;
        }
    }
}
