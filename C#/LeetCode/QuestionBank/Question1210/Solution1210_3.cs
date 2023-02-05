using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1210
{
    public class Solution1210_3 : Interface1210
    {
        /// <summary>
        /// BFS
        /// 本质上与Solution1210一样，这里使用数组代替Hash表，使用元组代替Struct
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int MinimumMoves(int[][] grid)
        {
            int steps = 0, len = grid.Length;
            int[,] visited = new int[len, len];  // 0:没访问过, 1: 访问过横向, 2: 访问过纵向, 3: 访问过两个方向
            visited[0, 0] |= 1;
            Queue<(int row, int col, int type)> queue = new Queue<(int row, int col, int type)>();  // type: 1: 横向, 2: 纵向
            queue.Enqueue((0, 0, 1));
            int cnt; while ((cnt = queue.Count) > 0)
            {
                for (int i = 0; i < cnt; i++)
                {
                    var info = queue.Dequeue();
                    int row = info.row, col = info.col;
                    if (info.type == 1)
                    {
                        if (row == len - 1 && col == len - 2) return steps;
                        if (col + 2 < len && grid[row][col + 2] != 1 && (visited[row, col + 1] & 1) != 1)
                        {
                            queue.Enqueue((row, col + 1, 1)); visited[row, col + 1] |= 1;
                        }
                        if (row + 1 < len && grid[row + 1][col] != 1 && grid[row + 1][col + 1] != 1)
                        {
                            if ((visited[row + 1, col] & 1) != 1)
                            {
                                queue.Enqueue((row + 1, col, 1)); visited[row + 1, col] |= 1;
                            }
                            if ((visited[row, col] & 2) != 2)
                            {
                                queue.Enqueue((row, col, 2)); visited[row, col] |= 2;
                            }
                        }
                    }
                    else
                    {
                        if (row + 2 < len && grid[row + 2][col] != 1 && (visited[row + 1, col] & 2) != 2)
                        {
                            queue.Enqueue((row + 1, col, 2)); visited[row + 1, col] |= 2;
                        }
                        if (col + 1 < len && grid[row][col + 1] != 1 && grid[row + 1][col + 1] != 1)
                        {
                            if ((visited[row, col + 1] & 2) != 2)
                            {
                                queue.Enqueue((row, col + 1, 2)); visited[row, col + 1] |= 2;
                            }
                            if ((visited[row, col] & 1) != 1)
                            {
                                queue.Enqueue((row, col, 1)); visited[row, col] |= 1;
                            }
                        }
                    }
                }
                steps++;
            }

            return -1;
        }
    }
}
