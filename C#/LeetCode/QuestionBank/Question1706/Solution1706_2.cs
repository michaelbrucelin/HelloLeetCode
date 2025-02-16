using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1706
{
    public class Solution1706_2 : Interface1706
    {
        /// <summary>
        /// 模拟，dfs + 记忆化
        /// 逻辑同Solution1706，只是使用了记忆化
        /// 反而变慢了，应该是数据量太小导致的
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int[] FindBall(int[][] grid)
        {
            int rcnt = grid.Length, ccnt = grid[0].Length;
            int[] result = new int[ccnt];
            Dictionary<(int r, int c, int from), int> memory = new Dictionary<(int r, int c, int from), int>();
            for (int i = 0; i < ccnt; i++) result[i] = dfs(0, i, 0);

            return result;

            int dfs(int r, int c, int from)  // from: 0 从上面来，1 从侧面来
            {
                if (r == rcnt) return c;
                if (memory.ContainsKey((r, c, from))) return memory[(r, c, from)];

                int result;
                if (from == 0)
                {
                    if (grid[r][c] == 1 && (c == ccnt - 1 || grid[r][c + 1] == -1)) result = -1;
                    else if (grid[r][c] == -1 && (c == 0 || grid[r][c - 1] == 1)) result = -1;
                    else result = dfs(r, c + grid[r][c], 1);
                }
                else
                {
                    result = dfs(r + 1, c, 0);
                }
                memory.Add((r, c, from), result);

                return result;
            }
        }

        /// <summary>
        /// 逻辑同FindBall，只是将字典换成了数组
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int[] FindBall2(int[][] grid)
        {
            int rcnt = grid.Length, ccnt = grid[0].Length;
            int[] result = new int[ccnt];
            int[,,] memory = new int[rcnt, ccnt, 2];
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++) memory[r, c, 0] = memory[r, c, 1] = -2;
            for (int i = 0; i < ccnt; i++) result[i] = dfs(0, i, 0);

            return result;

            int dfs(int r, int c, int from)  // from: 0 从上面来，1 从侧面来
            {
                if (r == rcnt) return c;
                if (memory[r, c, from] != -2) return memory[r, c, from];

                int result;
                if (from == 0)
                {
                    if (grid[r][c] == 1 && (c == ccnt - 1 || grid[r][c + 1] == -1)) result = -1;
                    else if (grid[r][c] == -1 && (c == 0 || grid[r][c - 1] == 1)) result = -1;
                    else result = dfs(r, c + grid[r][c], 1);
                }
                else
                {
                    result = dfs(r + 1, c, 0);
                }
                memory[r, c, from] = result;

                return result;
            }
        }
    }
}
