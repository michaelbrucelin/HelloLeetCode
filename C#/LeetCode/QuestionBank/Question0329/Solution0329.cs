using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0329
{
    public class Solution0329 : Interface0329
    {
        /// <summary>
        /// DFS + 记忆化搜索
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public int LongestIncreasingPath(int[][] matrix)
        {
            int rcnt = matrix.Length, ccnt = matrix[0].Length;
            int[,] memory = new int[rcnt, ccnt];
            int[] dirs = [-1, 0, 1, 0, -1];

            int result = 1;
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++)
                {
                    if (memory[r, c] == 0) dfs(r, c);
                    result = Math.Max(result, memory[r, c]);
                }

            return result;

            int dfs(int r, int c)
            {
                if (memory[r, c] != 0) return memory[r, c];

                int result = 0;
                for (int i = 0, _r, _c; i < 4; i++)
                {
                    _r = r + dirs[i]; _c = c + dirs[i + 1];
                    if (_r < 0 || _r >= rcnt || _c < 0 || _c >= ccnt || matrix[_r][_c] <= matrix[r][c]) continue;
                    result = Math.Max(result, dfs(r + dirs[i], c + dirs[i + 1]));
                }
                memory[r, c] = ++result;

                return result;
            }
        }
    }
}
