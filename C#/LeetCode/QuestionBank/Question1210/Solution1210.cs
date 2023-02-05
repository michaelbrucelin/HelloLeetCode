using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1210
{
    public class Solution1210 : Interface1210
    {
        /// <summary>
        /// BFS
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int MinimumMoves(int[][] grid)
        {
            int steps = 0, len = grid.Length;
            Position start = new Position((0, 0), true);
            HashSet<Position> visited = new HashSet<Position>() { start };
            Queue<Position> queue = new Queue<Position>(); queue.Enqueue(start);
            int cnt; while ((cnt = queue.Count) > 0)
            {
                for (int i = 0; i < cnt; i++)
                {
                    Position position = queue.Dequeue();
                    int row = position.point.row, col = position.point.col;
                    if (position.direction)
                    {
                        if (row == len - 1 && col == len - 2) return steps;
                        if (col + 2 < len && grid[row][col + 2] != 1)
                        {
                            Position _p1 = new Position((row, col + 1), true);
                            if (!visited.Contains(_p1))
                            {
                                queue.Enqueue(_p1); visited.Add(_p1);
                            }
                        }
                        if (row + 1 < len && grid[row + 1][col] != 1 && grid[row + 1][col + 1] != 1)
                        {
                            Position _p2 = new Position((row + 1, col), true);
                            if (!visited.Contains(_p2))
                            {
                                queue.Enqueue(_p2); visited.Add(_p2);
                            }
                            Position _p3 = new Position((row, col), false);
                            if (!visited.Contains(_p3))
                            {
                                queue.Enqueue(_p3); visited.Add(_p3);
                            }
                        }
                    }
                    else
                    {
                        if (row + 2 < len && grid[row + 2][col] != 1)
                        {
                            Position _p1 = new Position((row + 1, col), false);
                            if (!visited.Contains(_p1))
                            {
                                queue.Enqueue(_p1); visited.Add(_p1);
                            }
                        }
                        if (col + 1 < len && grid[row][col + 1] != 1 && grid[row + 1][col + 1] != 1)
                        {
                            Position _p2 = new Position((row, col + 1), false);
                            if (!visited.Contains(_p2))
                            {
                                queue.Enqueue(_p2); visited.Add(_p2);
                            }
                            Position _p3 = new Position((row, col), true);
                            if (!visited.Contains(_p3))
                            {
                                queue.Enqueue(_p3); visited.Add(_p3);
                            }
                        }
                    }
                }
                steps++;
            }

            return -1;
        }

        private struct Position
        {
            public Position((int row, int col) point, bool direction)
            {
                this.point = point;
                this.direction = direction;
            }

            /// <summary>
            /// 蛇尾巴的坐标
            /// </summary>
            public (int row, int col) point;

            /// <summary>
            /// 方向：true: 横; false: 竖;
            /// </summary>
            public bool direction;
        }
    }
}
