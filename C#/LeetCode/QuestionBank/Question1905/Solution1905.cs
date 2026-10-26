using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1905
{
    public class Solution1905 : Interface1905
    {
        /// <summary>
        /// DFS
        /// </summary>
        /// <param name="grid1"></param>
        /// <param name="grid2"></param>
        /// <returns></returns>
        public int CountSubIslands(int[][] grid1, int[][] grid2)
        {
            int result = 0, rcnt = grid1.Length, ccnt = grid1[0].Length;
            bool[,] visited = new bool[rcnt, ccnt];
            int[] dirs = [-1, 0, 1, 0, -1];
            bool flag;
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++) if (grid2[r][c] != 0 && !visited[r, c])
                    {
                        flag = true;
                        dfs(r, c, ref flag);
                        if (flag) result++;
                    }

            return result;

            void dfs(int r, int c, ref bool flag)
            {
                if (grid2[r][c] == 0 || visited[r, c]) return;
                flag = flag && grid1[r][c] == 1;
                visited[r, c] = true;
                for (int i = 0, _r, _c; i < 4; i++)
                {
                    _r = r + dirs[i]; _c = c + dirs[i + 1];
                    if (_r >= 0 && _r < rcnt && _c >= 0 && _c < ccnt) dfs(_r, _c, ref flag);
                }
            }
        }
    }
}
