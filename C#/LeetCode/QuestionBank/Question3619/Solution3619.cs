using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3619
{
    public class Solution3619 : Interface3619
    {
        /// <summary>
        /// DFS
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int CountIslands(int[][] grid, int k)
        {
            int result = 0, rcnt = grid.Length, ccnt = grid[0].Length;
            bool[,] visited = new bool[rcnt, ccnt];
            int[] dirs = [-1, 0, 1, 0, -1];

            long sum;
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++) if (grid[r][c] > 0 && !visited[r, c])
                    {
                        sum = 0;
                        dfs(r, c, ref sum);
                        if (sum % k == 0) result++;
                    }
            return result;

            void dfs(int r, int c, ref long sum)
            {
                if (grid[r][c] == 0 || visited[r, c]) return;
                sum += grid[r][c];
                visited[r, c] = true;
                for (int i = 0, _r, _c; i < 4; i++)
                {
                    _r = r + dirs[i]; _c = c + dirs[i + 1];
                    if (_r >= 0 && _r < rcnt && _c >= 0 && _c < ccnt) dfs(_r, _c, ref sum);
                }
            }
        }
    }
}
