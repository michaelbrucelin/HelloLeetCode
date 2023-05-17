using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1335
{
    public class Solution1335 : Interface1335
    {
        /// <summary>
        /// DFS + 记忆化搜索
        /// 题目就是要把数组分为d个子数组，使得每个子数组的最大值的总和最小
        /// 1. O(n^2)可以得到任意子数组的最大值
        /// 2. DFS模拟不同的分组
        /// </summary>
        /// <param name="jobDifficulty"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public int MinDifficulty(int[] jobDifficulty, int d)
        {
            int len = jobDifficulty.Length;
            if (len < d) return -1;
            if (len == d) return jobDifficulty.Sum();

            int[,] memory = new int[len, d];
            for (int r = 0; r < len; r++) for (int c = 0; c < d; c++) memory[r, c] = -2;
            for (int r = len - 1; r > len - d; r--) for (int c = d - 1; c > len - r - 1; c--) memory[r, c] = -1;

            int[,] submax = new int[len, len];
            for (int i = 0, _max; i < len; i++)
            {
                submax[i, i] = _max = jobDifficulty[i];
                for (int j = i + 1; j < len; j++)
                    submax[i, j] = _max = Math.Max(_max, jobDifficulty[j]);
            }

            return dfs(jobDifficulty, 0, d, submax, memory);
        }

        private int dfs(int[] jobDifficulty, int start, int d, int[,] submax, int[,] memory)
        {
            int len = jobDifficulty.Length;
            if (memory[start, d - 1] != -2) return memory[start, d - 1];

            if (d == 1)
            {
                memory[start, d - 1] = submax[start, len - 1];
            }
            else
            {
                int result = int.MaxValue;
                for (int i = start; i <= len - d; i++)
                    result = Math.Min(result, submax[start, i] + dfs(jobDifficulty, i + 1, d - 1, submax, memory));
                memory[start, d - 1] = result;
            }

            return memory[start, d - 1];
        }
    }
}
