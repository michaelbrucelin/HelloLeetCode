using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0096
{
    public class Solution0096_2 : Interface0096
    {
        /// <summary>
        /// 递推
        /// 逻辑完全同Solution0096，将递归改为递推
        /// 
        /// 这组数据有通项公式（卡特兰数），这里就不做了
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int NumTrees(int n)
        {
            if (n < 2) return 1;

            int[] dp = new int[n + 1];
            dp[0] = dp[1] = 1;
            for (int i = 2; i <= n; i++) for (int j = 1; j <= i; j++)
                {
                    dp[i] += dp[j - 1] * dp[i - j];
                }

            return dp[n];
        }
    }
}
