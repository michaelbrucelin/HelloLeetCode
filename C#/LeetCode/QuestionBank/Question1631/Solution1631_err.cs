using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1631
{
    public class Solution1631_err : Interface1631
    {
        private static readonly int[] dirs = new int[] { -1, 0, 1, 0, -1 };

        /// <summary>
        /// DFS + 记忆化搜索
        /// 同Solution1631，添加记忆化加速，记录每个位置从不同位置进入时，到达终点的最小值
        /// 
        /// 思路是错误的，如果记忆化，那么Key除了需要包含从哪个方向进入的，还需要包含visited
        /// </summary>
        /// <param name="heights"></param>
        /// <returns></returns>
        public int MinimumEffortPath(int[][] heights)
        {
            int rcnt = heights.Length, ccnt = heights[0].Length;
            bool[,] visited = new bool[rcnt, ccnt];
            int[,,] memory = new int[rcnt, ccnt, 4];  // 上:0, 右:1, 下:2, 左:3, 与dirs一致
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++) for (int i = 0; i < 4; i++) memory[r, c, i] = -1;

            return dfs(heights, rcnt, ccnt, 0, 0, visited, memory);
        }

        private int dfs(int[][] heights, int rcnt, int ccnt, int r, int c, bool[,] visited, int[,,] memory)
        {
            if (r == rcnt - 1 && c == ccnt - 1) return 0;

            int result = int.MaxValue;
            visited[r, c] = true;
            for (int i = 0, _r, _c, _result; i < 4; i++)
            {
                _r = r + dirs[i]; _c = c + dirs[i + 1];
                if (_r >= 0 && _r < rcnt && _c >= 0 && _c < ccnt && !visited[_r, _c])
                {
                    if (memory[_r, _c, i] == -1)
                    {
                        bool[,] _visited = (bool[,])visited.Clone();
                        memory[_r, _c, i] = dfs(heights, rcnt, ccnt, _r, _c, _visited, memory);
                    }
                    _result = Math.Max(Math.Abs(heights[_r][_c] - heights[r][c]), memory[_r, _c, i]);
                    result = Math.Min(result, _result);
                }
            }

            return result;
        }
    }
}
