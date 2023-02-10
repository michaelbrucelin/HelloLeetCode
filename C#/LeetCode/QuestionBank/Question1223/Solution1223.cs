using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1223
{
    public class Solution1223 : Interface1223
    {
        private const int MOD = 1000000007;

        /// <summary>
        /// DFS
        /// 前4个测试用例可以通过，逻辑应该没有问题，但是测试数据大就跑不出来了，参考测试用例4-7
        /// 
        /// 没想明白能不能用类似于容斥原理等方式，直接数学推导出来，先DFS解一下
        /// </summary>
        /// <param name="n"></param>
        /// <param name="rollMax"></param>
        /// <returns></returns>
        public int DieSimulator(int n, int[] rollMax)
        {
            if (n == 1) return 6;

            int result = 0;
            for (int i = 1; i <= 6; i++) dfs(i, 1, 1, n - 1, rollMax, ref result);

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point">上一轮掷出的点数</param>
        /// <param name="freq">上一轮掷出点数的连续次数</param>
        /// <param name="count">已经产生的不同序列数</param>
        /// <param name="times">剩余的掷骰子数</param>
        /// <param name="limit">rollMax</param>
        /// <param name="result"></param>
        private void dfs(int point, int freq, int count, int times, int[] limit, ref int result)
        {
            if (times == 0) { result += count % MOD; result %= MOD; return; }
            for (int i = 1; i <= 6; i++)
            {
                if (i != point)
                {
                    dfs(i, 1, count, times - 1, limit, ref result);
                }
                else
                {
                    if (freq < limit[i - 1]) dfs(i, freq + 1, count, times - 1, limit, ref result);
                }
            }
        }
    }
}
