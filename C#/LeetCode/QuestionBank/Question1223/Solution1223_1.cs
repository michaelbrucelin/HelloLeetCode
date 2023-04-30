using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1223
{
    public class Solution1223_1 : Interface1223
    {
        private const int MOD = 1000000007;

        /// <summary>
        /// DFS
        /// 与Solution1223一样，将dfs的6个入口，改为了一个入口
        /// </summary>
        /// <param name="n"></param>
        /// <param name="rollMax"></param>
        /// <returns></returns>
        public int DieSimulator(int n, int[] rollMax)
        {
            if (n == 1) return 6;

            int result = 0;
            int[] limit = new int[7];  // 构造新的rollMax数组，这样dfs时就一个入口，否则需要6个入口
            for (int i = 1; i <= 6; i++) limit[i] = rollMax[i - 1];

            dfs(0, 1, 1, n, limit, ref result);

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
                    if (freq < limit[i]) dfs(i, freq + 1, count, times - 1, limit, ref result);
                }
            }
        }
    }
}
