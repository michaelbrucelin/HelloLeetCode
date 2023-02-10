using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1223
{
    public class Solution1223_1_2 : Interface1223
    {
        private const int MOD = 1000000007;

        /// <summary>
        /// 记忆化搜索
        /// 由于DFS太慢，而且存在大量的重复运算，这里使用记忆化搜索来优化
        /// 
        /// 未完成，有时间再写。
        /// </summary>
        /// <param name="n"></param>
        /// <param name="rollMax"></param>
        /// <returns></returns>
        public int DieSimulator(int n, int[] rollMax)
        {
            if (n == 1) return 6;

            int result = 0;
            for (int i = 1; i <= 6; i++) result += dfs(i, 1, 1, n - 1, rollMax);

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
        private int dfs(int point, int freq, int count, int times, int[] limit)
        {
            if (times == 0) return count;

            int _count = 0;
            for (int i = 1; i <= 6; i++)
            {
                if (i != point)
                {
                    _count += dfs(i, 1, count, times - 1, limit);
                }
                else
                {
                    if (freq < limit[i - 1]) _count += dfs(i, freq + 1, count, times - 1, limit);
                }
            }

            return count * _count;
        }
    }
}
