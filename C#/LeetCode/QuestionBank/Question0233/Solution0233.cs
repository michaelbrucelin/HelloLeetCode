using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0233
{
    public class Solution0233 : Interface0233
    {
        /// <summary>
        /// 数位DP
        /// dp[i,j]表示首位是j的i位数的结果
        /// 
        /// 代码是错的，不写了
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int CountDigitOne(int n)
        {
            if (n == 0) return 0;

            int len = 0; for (int _n = n; _n > 0; _n /= 10) len++;
            int[,] dp = new int[len + 1, 10];
            for (int i = 1, cnt = 1; i <= len; i++, cnt *= 10) for (int j = 0; j < 10; j++)
                {
                    for (int k = 0; k < 10; k++) dp[i, j] += dp[i - 1, k];
                    if (j == 1) dp[i, j] += cnt;
                }

            int result = 0;
            for (int i = 1, _n = n; _n > 0; i++, _n /= 10) for (int j = _n % 10; j > 0; j--) result += dp[i, j];
            return result;
        }
    }
}
