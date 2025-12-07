using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1162
{
    public class Solution1162 : Interface1162
    {
        private readonly static (int, int)[] directions = [(-1, 0), (0, 1), (1, 0), (0, -1)];

        /// <summary>
        /// 遍历每一个“海洋”点，BFS找出最近的陆地
        /// 提交会超时，参考测试用例5
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int MaxDistance(int[][] grid)
        {
            int result = -1, n = grid.Length;
            for (int i = 0; i < n; i++)
            {
                int dis_y = Math.Max(i, n - 1 - i);
                for (int j = 0; j < n; j++)
                {
                    int dis_x = Math.Max(j, n - 1 - j);
                    if (grid[i][j] == 1 || dis_y + dis_x <= result) continue;
                    HashSet<(int, int)> ocean = new HashSet<(int, int)>() { (i, j) };
                    Queue<(int, int)> queue = new Queue<(int, int)>(); queue.Enqueue((i, j));
                    int steps = 0;
                    int cnt; while ((cnt = queue.Count) > 0)
                    {
                        steps++;
                        for (int k = 0; k < cnt; k++)
                        {
                            (int x, int y) sea = queue.Dequeue();
                            foreach ((int x, int y) direction in directions)
                            {
                                (int x, int y) point = (sea.x + direction.x, sea.y + direction.y);
                                if (point.x >= 0 && point.x < n && point.y >= 0 && point.y < n)
                                {
                                    if (grid[point.x][point.y] == 1)
                                    {
                                        if (steps > result) result = steps;
                                        goto Find;
                                    }
                                    else if (!ocean.Contains(point))
                                    {
                                        ocean.Add(point); queue.Enqueue(point);
                                    }
                                }
                            }
                        }
                    }
                Find:;
                }
            }

            return result;
        }
    }
}
