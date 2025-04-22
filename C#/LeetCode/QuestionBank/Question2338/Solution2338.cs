using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2338
{
    public class Solution2338 : Interface2338
    {
        /// <summary>
        /// DP
        /// 使用一个数组记录长度为N，结尾为x的理想数组的数量，那么很容易计算出长度为N+1，结尾为y的理想数组的数量
        /// 时间复杂度为O(n*maxValue*maxValue)，大概率会TLE
        /// 
        /// 意料之中的TLE，参考测试用例04
        /// </summary>
        /// <param name="n"></param>
        /// <param name="maxValue"></param>
        /// <returns></returns>
        public int IdealArrays(int n, int maxValue)
        {
            if (n == 1) return maxValue;

            const int MOD = (int)1e9 + 7;
            int[] dp = new int[maxValue + 1], _dp = new int[maxValue + 1];
            Array.Fill(dp, 1);
            for (int _n = 1; _n < n; _n++)
            {
                Array.Fill(_dp, 0);
                for (int i = 1; i <= maxValue; i++) for (int j = 1; j <= i; j++)
                    {
                        if (i % j == 0) _dp[i] = (_dp[i] + dp[j]) % MOD;
                    }
                Array.Copy(_dp, dp, maxValue + 1);
            }

            int result = 0;
            for (int i = 1; i <= maxValue; i++) result = (result + dp[i]) % MOD;
            return result;
        }

        /// <summary>
        /// 逻辑同IdealArrays()，稍加优化
        /// 依然TLE，参考测试用例05
        /// </summary>
        /// <param name="n"></param>
        /// <param name="maxValue"></param>
        /// <returns></returns>
        public int IdealArrays2(int n, int maxValue)
        {
            if (n == 1) return maxValue;

            List<int>[] divs = new List<int>[maxValue + 1];
            for (int i = 1; i <= maxValue; i++)
            {
                divs[i] = new List<int>();
                for (int j = 1; j <= i; j++) if (i % j == 0) divs[i].Add(j);
            }

            const int MOD = (int)1e9 + 7;
            int[] dp = new int[maxValue + 1], _dp = new int[maxValue + 1];
            Array.Fill(dp, 1);
            for (int _n = 1; _n < n; _n++)
            {
                Array.Fill(_dp, 0);
                for (int i = 1; i <= maxValue; i++) foreach (int j in divs[i])
                    {
                        _dp[i] = (_dp[i] + dp[j]) % MOD;
                    }
                Array.Copy(_dp, dp, maxValue + 1);
            }

            int result = 0;
            for (int i = 1; i <= maxValue; i++) result = (result + dp[i]) % MOD;
            return result;
        }
    }
}
