using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2132
{
    public class Solution2132_2 : Interface2132
    {        /// <summary>
             /// 与Solution2132.PossibleToStamp2()一样，将4个方向的bool变量合并为一个int掩码
             /// </summary>
             /// <param name="grid"></param>
             /// <param name="stampHeight"></param>
             /// <param name="stampWidth"></param>
             /// <returns></returns>
        public bool PossibleToStamp(int[][] grid, int stampHeight, int stampWidth)
        {
            int rcnt = grid.Length, ccnt = grid[0].Length;
            bool[,] visited = new bool[rcnt, ccnt];
            int left, right, up, down, mask;
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++)
                {
                    if (grid[r][c] == 1 || visited[r, c]) continue;
                    up = down = r; left = right = c; mask = 0;
                    while (mask != 15)
                    {
                        // 向上BFS
                        if ((mask & 1) != 1) bfs(grid, ref mask, 1, ref up, 0, -1, up - 1, up - 1, left, right);
                        // 向右BFS
                        if ((mask & 2) != 2) bfs(grid, ref mask, 2, ref right, ccnt - 1, 1, up, down, right + 1, right + 1);
                        // 向下BFS
                        if ((mask & 4) != 4) bfs(grid, ref mask, 4, ref down, rcnt - 1, 1, down + 1, down + 1, left, right);
                        // 向左BFS
                        if ((mask & 8) != 8) bfs(grid, ref mask, 8, ref left, 0, -1, up, down, left - 1, left - 1);
                    }

                    // 验证BFS后的区域
                    if (down - up + 1 < stampHeight || right - left + 1 < stampWidth) return false;
                    for (int _r = up; _r <= down; _r++) for (int _c = left; _c <= right; _c++) visited[_r, _c] = true;
                }

            return true;
        }

        /// <summary>
        /// 对4个方向BFS的封装
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="mask">向哪个方向BFS</param>
        /// <param name="curr">当前位置</param>
        /// <param name="border">边界位置：0, rcnt-1, ccnt-1</param>
        /// <param name="increment">增量：1, -1</param>
        /// <param name="r1">起始行位置</param>
        /// <param name="r2">终止行位置</param>
        /// <param name="c1">起始列位置</param>
        /// <param name="c2">终止列位置</param>
        private void bfs(int[][] grid, ref int mask, int _mask, ref int curr, int border, int increment, int r1, int r2, int c1, int c2)
        {
            if (curr == border)
            {
                mask |= _mask;
            }
            else
            {
                curr += increment;
                for (int r = r1; r <= r2; r++) for (int c = c1; c <= c2; c++) if (grid[r][c] == 1)
                        {
                            mask |= _mask; curr -= increment; goto EndLoop;
                        }
                EndLoop:;
            }
        }
    }
}
