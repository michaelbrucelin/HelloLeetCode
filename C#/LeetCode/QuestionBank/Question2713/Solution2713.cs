using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2713
{
    public class Solution2713 : Interface2713
    {
        /// <summary>
        /// DFS + 记忆化搜索
        /// 目测会TLE，先写出来试试
        /// 
        /// 意料之中的TLE，而且在.net core 8中会栈溢出，参考测试用例04
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        public int MaxIncreasingCells(int[][] mat)
        {
            int rcnt = mat.Length, ccnt = mat[0].Length;
            int[,] memory = new int[rcnt, ccnt];
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++)
                {
                    if (memory[r, c] == 0) dfs(mat, r, c, memory);
                }

            int result = 0;
            foreach (int val in memory) result = Math.Max(result, val);
            return result;
        }

        private void dfs(int[][] mat, int r, int c, int[,] memory)
        {
            int result = 0, rcnt = mat.Length, ccnt = mat[0].Length;
            for (int _r = 0; _r < rcnt; _r++) if (mat[_r][c] > mat[r][c])
                {
                    if (memory[_r, c] == 0) dfs(mat, _r, c, memory);
                    result = Math.Max(result, memory[_r, c]);
                }
            for (int _c = 0; _c < ccnt; _c++) if (mat[r][_c] > mat[r][c])
                {
                    if (memory[r, _c] == 0) dfs(mat, r, _c, memory);
                    result = Math.Max(result, memory[r, _c]);
                }

            memory[r, c] = result + 1;
        }
    }
}
