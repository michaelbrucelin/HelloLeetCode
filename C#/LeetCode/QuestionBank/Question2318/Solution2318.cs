using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2318
{
    public class Solution2318 : Interface2318
    {
        /// <summary>
        /// DP
        /// 令F(N,x,y)表示掷第N次骰子，其中最后依次掷y，倒第2次掷x的结果
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int DistinctSequences(int n)
        {
            int MOD = (int)1e9 + 7;
            int[,,] dp = new int[n + 1, 7, 7];


            int result = 0;
            for (int i = 1; i <= 6; i++) for (int j = 1; j <= 6; j++) result = (result + dp[n, i, j]) % MOD;
            return result;
        }
    }
}
