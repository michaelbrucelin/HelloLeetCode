using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1254
{
    public class Solution1254 : Interface1254
    {
        private static readonly (int r, int c)[] dirs = new (int r, int c)[] { (-1, 0), (0, 1), (1, 0), (0, -1) };

        /// <summary>
        /// BFS
        /// 封闭岛，即岛没有到达二维数组的边界
        /// 通过BFS来识别每个岛，识别过的位置改为-1
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int ClosedIsland(int[][] grid)
        {
            int result = 0, rcnt = grid.Length, ccnt = grid[0].Length;
            bool flag; int cnt, _r, _c;
            Queue<(int r, int c)> queue = new Queue<(int r, int c)>();
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++)
                {
                    if (grid[r][c] != 0) continue;
                    flag = true;
                    queue.Enqueue((r, c));
                    while ((cnt = queue.Count) > 0)
                    {
                        for (int i = 0; i < cnt; i++)
                        {
                            var pos = queue.Dequeue();
                            grid[pos.r][pos.c] = -1;
                            if (pos.r == 0 || pos.r == rcnt - 1 || pos.c == 0 || pos.c == ccnt - 1) flag = false;
                            for (int j = 0; j < 4; j++)
                            {
                                _r = pos.r + dirs[j].r; _c = pos.c + dirs[j].c;
                                if (_r >= 0 && _r < rcnt && _c >= 0 && _c < ccnt && grid[_r][_c] == 0) queue.Enqueue((_r, _c));
                            }
                        }
                    }
                    if (flag) result++;
                }

            return result;
        }
    }
}
