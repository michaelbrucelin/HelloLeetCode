using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0837
{
    public class Solution0837 : Interface0837
    {
        /// <summary>
        /// BFS
        /// 
        /// 逻辑没什么问题，TLE，参考测试用例05
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <param name="maxPts"></param>
        /// <returns></returns>
        public double New21Game(int n, int k, int maxPts)
        {
            if (k == 0 || k - 1 + maxPts <= n) return 1;

            double result = 0, unit = 1D / maxPts;
            double[] dp = new double[k + maxPts + 1], _dp = new double[k + maxPts + 1];
            for (int i = 1; i <= maxPts; i++) dp[i] = unit;
            for (int i = k; i <= n; i++) result += dp[i];
            while (dp.Where((val, idx) => idx < k).Any(x => x > 0))
            {
                Array.Fill(_dp, 0);
                for (int i = 1; i <= maxPts; i++) for (int j = 1; j < k; j++)  // 模拟随机，i表示随机到i分，j表示上一轮积累到j分
                    {
                        _dp[j + i] += dp[j] * unit;
                    }
                for (int i = 1; i <= n; i++) dp[i] = _dp[i];
                for (int i = k; i <= n; i++) result += _dp[i];
            }

            return result;
        }
    }
}
