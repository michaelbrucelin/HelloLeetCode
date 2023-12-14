using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2132
{
    public class Solution2132 : Interface2132
    {
        /// <summary>
        /// 模拟，BFS
        /// 每一个空的格子，都BFS外扩，扩充到一个最大的矩形，如果可以扩充出的空间大于一个邮票的size，那么这些格子就都可覆盖，否则这些格子不可覆盖
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="stampHeight"></param>
        /// <param name="stampWidth"></param>
        /// <returns></returns>
        public bool PossibleToStamp(int[][] grid, int stampHeight, int stampWidth)
        {
            int rcnt = grid.Length, ccnt = grid[0].Length;
            bool[,] visited = new bool[rcnt, ccnt];
            int left, right, up, down;
            bool to_left, to_right, to_up, to_down;  // 这4个bool值可以优化为一个掩码
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++)
                {
                    if (grid[r][c] == 1 || visited[r, c]) continue;
                    up = down = r; left = right = c;
                    to_up = to_down = to_left = to_right = true;
                    while (to_left || to_right || to_up || to_down)
                    {
                        // 向上BFS
                        if (to_up)
                        {
                            if (up == 0)
                            {
                                to_up = false;
                            }
                            else
                            {
                                up--;
                                for (int _c = left; _c <= right; _c++) if (grid[up][_c] == 1)
                                    {
                                        to_up = false; up++; break;
                                    }
                            }
                        }
                        // 向右BFS
                        if (to_right)
                        {
                            if (right == ccnt - 1)
                            {
                                to_right = false;
                            }
                            else
                            {
                                right++;
                                for (int _r = up; _r <= down; _r++) if (grid[_r][right] == 1)
                                    {
                                        to_right = false; right--; break;
                                    }
                            }
                        }
                        // 向下BFS
                        if (to_down)
                        {
                            if (down == rcnt - 1)
                            {
                                to_down = false;
                            }
                            else
                            {
                                down++;
                                for (int _c = left; _c <= right; _c++) if (grid[down][_c] == 1)
                                    {
                                        to_down = false; down--; break;
                                    }
                            }
                        }
                        // 向左BFS
                        if (to_left)
                        {
                            if (left == 0)
                            {
                                to_left = false;
                            }
                            else
                            {
                                left--;
                                for (int _r = up; _r <= down; _r++) if (grid[_r][left] == 1)
                                    {
                                        to_left = false; left++; break;
                                    }
                            }
                        }
                    }

                    // 验证BFS后的区域
                    if (down - up + 1 < stampHeight || right - left + 1 < stampWidth) return false;
                    for (int _r = up; _r <= down; _r++) for (int _c = left; _c <= right; _c++) visited[_r, _c] = true;
                }

            return true;
        }

        /// <summary>
        /// 与PossibleToStamp()一样，将向4个方向BFS的代码封装起来
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="stampHeight"></param>
        /// <param name="stampWidth"></param>
        /// <returns></returns>
        public bool PossibleToStamp2(int[][] grid, int stampHeight, int stampWidth)
        {
            int rcnt = grid.Length, ccnt = grid[0].Length;
            bool[,] visited = new bool[rcnt, ccnt];
            int left, right, up, down;
            bool to_left, to_right, to_up, to_down;  // 这4个bool值可以优化为一个掩码
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++)
                {
                    if (grid[r][c] == 1 || visited[r, c]) continue;
                    up = down = r; left = right = c;
                    to_up = to_down = to_left = to_right = true;
                    while (to_left || to_right || to_up || to_down)
                    {
                        // 向上BFS
                        if (to_up) bfs(grid, ref to_up, ref up, 0, -1, up - 1, up - 1, left, right);
                        // 向右BFS
                        if (to_right) bfs(grid, ref to_right, ref right, ccnt - 1, 1, up, down, right + 1, right + 1);
                        // 向下BFS
                        if (to_down) bfs(grid, ref to_down, ref down, rcnt - 1, 1, down + 1, down + 1, left, right);
                        // 向左BFS
                        if (to_left) bfs(grid, ref to_left, ref left, 0, -1, up, down, left - 1, left - 1);
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
        /// <param name="direction">向哪个方向BFS</param>
        /// <param name="curr">当前位置</param>
        /// <param name="border">边界位置：0, rcnt-1, ccnt-1</param>
        /// <param name="increment">增量：1, -1</param>
        /// <param name="r1">起始行位置</param>
        /// <param name="r2">终止行位置</param>
        /// <param name="c1">起始列位置</param>
        /// <param name="c2">终止列位置</param>
        private void bfs(int[][] grid, ref bool direction, ref int curr, int border, int increment, int r1, int r2, int c1, int c2)
        {
            if (curr == border)
            {
                direction = false;
            }
            else
            {
                curr += increment;
                for (int r = r1; r <= r2; r++) for (int c = c1; c <= c2; c++) if (grid[r][c] == 1)
                        {
                            direction = false; curr -= increment; goto EndLoop;
                        }
                EndLoop:;
            }
        }
    }
}
