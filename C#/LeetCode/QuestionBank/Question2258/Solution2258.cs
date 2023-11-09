using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2258
{
    public class Solution2258 : Interface2258
    {
        private static readonly int[] dir = new int[] { 1, 0, -1, 0, 1 };

        /// <summary>
        /// BFS + 二分法
        /// 1. n秒后人可到达的位置与火势可达的范围都可以通过BFS来实现
        ///     如果产生交集，算火的范围，不算人的范围
        ///     如果人可以先到达安全屋，有解，如果火先达到安全屋，无解
        /// 2. 先人BFS，看看人需要多久可以到达安全屋，假设人需要x秒到达安全屋
        /// 3. 再火势BFS，看看火需要多久会到达安全屋，假设火势需要y秒到达安全屋
        ///     如果y<x，无解，即解为-1
        ///     如果不可到达安全屋，人可以在任意时间出发，即解为10^9
        /// 4. 在wait in [x, y]之间，使用二分法检验人在原地等待wait秒后是否可以到达安全屋
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int MaximumMinutes(int[][] grid)
        {
            int low = SoloTime(grid, 0);           // 计算人的时间
            if (low == -1) return -1;
            int high = SoloTime(grid, 1);          // 计算火势时间
            if (high == -1) return 1000000000; else if (high < low) return -1;

            int result = -1, rcnt = grid.Length, ccnt = grid[0].Length;
            int[,] visited = new int[rcnt, ccnt];  // 记录火势蔓延的范围
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++)
                {
                    // visited[r,c]=n表示人在原地等待n秒火的位置，这样只需要将visited没有火的位置初始化为-1，稍后就不需要重置visited了
                    if (grid[r][c] == 0) visited[r, c] = -1;
                }

            high -= low; low = 0; int mid;
            while (low <= high)
            {
                mid = low + ((high - low) >> 1);
                if (BeSafe(grid, visited, mid))
                {
                    result = mid; low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }

            return result;
        }

        /// <summary>
        /// 计算人或火势多久会到达安全屋
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="flag">0, 人; 1, 火</param>
        /// <returns></returns>
        private int SoloTime(int[][] grid, int flag)
        {
            int steps = 0, rcnt = grid.Length, ccnt = grid[0].Length;
            bool[,] visited = new bool[rcnt, ccnt];
            Queue<(int r, int c)> queue = new Queue<(int r, int c)>();
            if (flag == 0)
            {
                queue.Enqueue((0, 0));
            }
            else
            {
                for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++)
                    {
                        if (grid[r][c] == 1) queue.Enqueue((r, c));
                    }
            }

            (int r, int c) pos;
            int cnt; while ((cnt = queue.Count) > 0)
            {
                steps++;
                for (int i = 0, _r, _c; i < cnt; i++)
                {
                    pos = queue.Dequeue(); visited[pos.r, pos.c] = true;
                    for (int j = 0; j < 4; j++)
                    {
                        _r = pos.r + dir[j]; _c = pos.c + dir[j + 1];
                        if (_r == rcnt - 1 && _c == ccnt - 1) return steps;
                        if (_r >= 0 && _r < rcnt && _c >= 0 && _c < ccnt && grid[_r][_c] == 0 && !visited[_r, _c])
                        {
                            queue.Enqueue((_r, _c));
                        }
                    }
                }
            }

            return -1;
        }

        /// <summary>
        /// 验证人是否可以到达安全屋
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="visited"></param>
        /// <param name="curr"></param>
        /// <returns></returns>
        private bool BeSafe(int[][] grid, int[,] visited_fire, int wait)
        {
            // 初始化
            int rcnt = grid.Length, ccnt = grid[0].Length;
            Queue<(int r, int c)> queue_fire = new Queue<(int r, int c)>();
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++) if (grid[r][c] == 1)
                    {
                        queue_fire.Enqueue((r, c)); visited_fire[r, c] = wait;
                    }

            // 火势先蔓延wait秒
            (int r, int c) pos; int cnt;
            for (int t = 0; t < wait; t++)
            {
                cnt = queue_fire.Count; for (int i = 0, _r, _c; i < cnt; i++)
                {
                    pos = queue_fire.Dequeue();
                    for (int j = 0; j < 4; j++)
                    {
                        _r = pos.r + dir[j]; _c = pos.c + dir[j + 1];
                        if (_r >= 0 && _r < rcnt && _c >= 0 && _c < ccnt && grid[_r][_c] == 0 && visited_fire[_r, _c] != wait)
                        {
                            queue_fire.Enqueue((_r, _c)); visited_fire[_r, _c] = wait;
                        }
                    }
                }
            }

            // 火与人一起BFS
            Queue<(int r, int c)> queue_man = new Queue<(int r, int c)>(); queue_man.Enqueue((0, 0));
            bool[,] visited_man = new bool[rcnt, ccnt];
            bool flag = false;  // 标记安全屋已经着火，因为如果人与火同时到达安全屋可以认为是安全的
            while (true)
            {
                // 火蔓延一次
                cnt = queue_fire.Count; for (int i = 0, _r, _c; i < cnt; i++)
                {
                    pos = queue_fire.Dequeue();
                    for (int j = 0; j < 4; j++)
                    {
                        _r = pos.r + dir[j]; _c = pos.c + dir[j + 1];
                        if (_r == rcnt - 1 && _c == ccnt - 1) flag = true;
                        if (_r >= 0 && _r < rcnt && _c >= 0 && _c < ccnt && grid[_r][_c] == 0 && visited_fire[_r, _c] != wait)
                        {
                            queue_fire.Enqueue((_r, _c)); visited_fire[_r, _c] = wait;
                        }
                    }
                }
                // 人前进一次
                cnt = queue_man.Count; for (int i = 0, _r, _c; i < cnt; i++)
                {
                    pos = queue_man.Dequeue(); visited_man[pos.r, pos.c] = true;
                    for (int j = 0; j < 4; j++)
                    {
                        _r = pos.r + dir[j]; _c = pos.c + dir[j + 1];
                        if (_r == rcnt - 1 && _c == ccnt - 1) return true;
                        if (_r >= 0 && _r < rcnt && _c >= 0 && _c < ccnt && grid[_r][_c] == 0 && visited_fire[_r, _c] != wait && !visited_man[_r, _c])
                        {
                            queue_man.Enqueue((_r, _c));
                        }
                    }
                }
                // 安全屋已经起火或人已经无处可走
                if (flag || queue_man.Count == 0) return false;
            }

            throw new Exception("Logical Error.");
        }
    }
}
