using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1706
{
    public class Solution1706 : Interface1706
    {
        /// <summary>
        /// 模拟，dfs
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int[] FindBall(int[][] grid)
        {
            int rcnt = grid.Length, ccnt = grid[0].Length;
            int[] result = new int[ccnt];
            for (int i = 0; i < ccnt; i++) result[i] = dfs(0, i, 0);

            return result;

            int dfs(int r, int c, int from)  // from: 0 从上面来，1 从侧面来
            {
                if (r == rcnt) return c;
                if (from == 0)
                {
                    if (grid[r][c] == 1 && (c == ccnt - 1 || grid[r][c + 1] == -1)) return -1;
                    if (grid[r][c] == -1 && (c == 0 || grid[r][c - 1] == 1)) return -1;
                    return dfs(r, c + grid[r][c], 1);
                }
                else
                {
                    return dfs(r + 1, c, 0);
                }
            }
        }
    }
}
