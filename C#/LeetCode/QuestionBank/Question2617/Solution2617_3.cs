using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2617
{
    public class Solution2617_3 : Interface2617
    {
        /// <summary>
        /// DP
        /// 将Solution2617_2中的DFS 1:1翻译为DP
        /// 
        /// 逻辑没问题，依然很慢，没有提交测试
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int MinimumVisitedCells(int[][] grid)
        {
            if (grid.Length == 1 && grid[0].Length == 1) return 1;

            int rcnt = grid.Length, ccnt = grid[0].Length;
            int[,] visited = new int[rcnt, ccnt];
            for (int r = rcnt - 1; r >= 0; r--) for (int c = ccnt - 1; c >= 0; c--)
                {
                    if (r == rcnt - 1 && c == ccnt - 1)
                    {
                        visited[r, c] = 1;
                    }
                    else
                    {
                        bool flag = false;
                        int cnt = rcnt + ccnt, rlimit = Math.Min(r + grid[r][c], rcnt - 1), climit = Math.Min(c + grid[r][c], ccnt - 1);
                        for (int _r = r + 1; _r <= rlimit; _r++) if (visited[_r, c] != -1)
                            {
                                cnt = Math.Min(cnt, visited[_r, c]); flag = true;
                            }
                        for (int _c = c + 1; _c <= climit; _c++) if (visited[r, _c] != -1)
                            {
                                cnt = Math.Min(cnt, visited[r, _c]); flag = true;
                            }
                        visited[r, c] = flag ? cnt + 1 : -1;
                    }
                }

            return visited[0, 0];
        }
    }
}
