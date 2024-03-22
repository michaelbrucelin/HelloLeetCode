using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2617
{
    public class Solution2617_2 : Interface2617
    {
        /// <summary>
        /// DFS + 记忆化搜索
        /// 
        /// 理论上只能比Solution2617慢，不会快，这里写着玩的，还可以1:1翻译为DP
        /// 逻辑没问题，但是TestCase06直接超出了clr允许的最大递归层数
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int MinimumVisitedCells(int[][] grid)
        {
            if (grid.Length == 1 && grid[0].Length == 1) return 1;

            int rcnt = grid.Length, ccnt = grid[0].Length;
            int[,] visited = new int[rcnt, ccnt];
            dfs(grid, rcnt, ccnt, 0, 0, visited);

            return visited[0, 0] != 0 ? visited[0, 0] : -1;
        }

        private void dfs(int[][] grid, int rcnt, int ccnt, int r, int c, int[,] visited)
        {
            if (r == rcnt - 1 && c == ccnt - 1)
            {
                visited[r, c] = 1;
            }
            else
            {
                bool flag = false;
                int cnt = rcnt + ccnt, rlimit = Math.Min(r + grid[r][c], rcnt - 1), climit = Math.Min(c + grid[r][c], ccnt - 1);
                for (int _r = r + 1; _r <= rlimit; _r++)
                {
                    if (visited[_r, c] == 0) dfs(grid, rcnt, ccnt, _r, c, visited);
                    if (visited[_r, c] != -1) { cnt = Math.Min(cnt, visited[_r, c]); flag = true; }
                }
                for (int _c = c + 1; _c <= climit; _c++)
                {
                    if (visited[r, _c] == 0) dfs(grid, rcnt, ccnt, r, _c, visited);
                    if (visited[r, _c] != -1) { cnt = Math.Min(cnt, visited[r, _c]); flag = true; }
                }
                visited[r, c] = flag ? cnt + 1 : -1;
            }
        }
    }
}
