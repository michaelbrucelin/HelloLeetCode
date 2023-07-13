using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0931
{
    public class Solution0931_2 : Interface0931
    {
        /// <summary>
        /// DFS + 记忆化搜索
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public int MinFallingPathSum(int[][] matrix)
        {
            int result = 10001, len = matrix.Length;  // 按题意，10001是一个上界
            int[,] memory = new int[len, len];
            for (int r = 0; r < len; r++) for (int c = 0; c < len; c++) memory[r, c] = int.MaxValue;
            for (int i = 0; i < len; i++)
                result = Math.Min(result, dfs(matrix, len, 0, i, memory));

            return result;
        }

        private int dfs(int[][] matrix, int len, int r, int c, int[,] memory)
        {
            if (r >= len) return 0;
            if (memory[r, c] != int.MaxValue) return memory[r, c];
            if (r == len - 1)
            {
                memory[r, c] = matrix[r][c]; return memory[r, c];
            }

            if (memory[r + 1, c] == int.MaxValue) memory[r + 1, c] = dfs(matrix, len, r + 1, c, memory);
            int next = memory[r + 1, c];
            if (c - 1 >= 0)
            {
                if (memory[r + 1, c - 1] == int.MaxValue) memory[r + 1, c - 1] = dfs(matrix, len, r + 1, c - 1, memory);
                next = Math.Min(next, memory[r + 1, c - 1]);
            }
            if (c + 1 < len)
            {
                if (memory[r + 1, c + 1] == int.MaxValue) memory[r + 1, c + 1] = dfs(matrix, len, r + 1, c + 1, memory);
                next = Math.Min(next, memory[r + 1, c + 1]);
            }

            return matrix[r][c] + next;
        }
    }
}
