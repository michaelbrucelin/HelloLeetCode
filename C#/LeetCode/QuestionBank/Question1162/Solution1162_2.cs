using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1162
{
    public class Solution1162_2 : Interface1162
    {
        private readonly static (int x, int y)[] directions = new (int x, int y)[] { (-1, 0), (0, 1), (1, 0), (0, -1) };

        /// <summary>
        /// 两层BFS
        /// 外层BFS用于从二维数组的四个角向中心遍历，内层BFS用于从一点向外找最近的岛
        /// 整体逻辑与Solution1162一致，但是由于Solution1162的代码提交会超时，这里进行一些必要优化
        /// 1. 从四个角向中心遍历，这个遍历也用到BFS
        /// 2. 某一次BFS时得到的结果已经是这一层BFS可能的最大值时，跳出BFS
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int MaxDistance(int[][] grid)
        {
            int result = -1, n = grid.Length;

            #region 外层BFS，从二维数组的四个角向中心遍历
            HashSet<(int x, int y)> mask = new HashSet<(int x, int y)>() { (0, 0), (0, n - 1), (n - 1, n - 1), (n - 1, 0) };
            Queue<(int x, int y)> queue = new Queue<(int x, int y)>(mask);
            int cnt; while ((cnt = queue.Count) > 0)
            {
                for (int i = 0; i < cnt; i++)
                {
                    (int x, int y) sea = queue.Dequeue();

                    #region 内层BFS，从一点向外找最近的岛
                    if (grid[sea.x][sea.y] == 0)
                    {
                        int max = Math.Max(sea.x, n - 1 - sea.x) + Math.Max(sea.y, n - 1 - sea.y);
                        if (max > result)
                        {
                            HashSet<(int x, int y)> _ocean = new HashSet<(int x, int y)>() { sea };
                            Queue<(int x, int y)> _queue = new Queue<(int x, int y)>(_ocean);
                            int steps = 0;
                            int _cnt; while ((_cnt = _queue.Count) > 0)
                            {
                                steps++;
                                for (int j = 0; j < _cnt; j++)
                                {
                                    var _sea = _queue.Dequeue();
                                    foreach (var direction in directions)
                                    {
                                        (int x, int y) _point = (_sea.x + direction.x, _sea.y + direction.y);
                                        if (_point.x >= 0 && _point.x < n && _point.y >= 0 && _point.y < n)
                                        {
                                            if (grid[_point.x][_point.y] == 1)
                                            {
                                                if (steps > result) result = steps;
                                                if (result == max) return result;
                                                goto Find;
                                            }
                                            else if (!_ocean.Contains(_point))
                                            {
                                                _ocean.Add(_point); _queue.Enqueue(_point);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        Find:;
                    }
                    #endregion

                    foreach (var direction in directions)
                    {
                        (int x, int y) point = (sea.x + direction.x, sea.y + direction.y);
                        if (point.x >= 0 && point.x < n && point.y >= 0 && point.y < n && !mask.Contains(point))
                        {
                            mask.Add(point); queue.Enqueue(point);
                        }
                    }
                }
            }
            #endregion

            return result;
        }
    }
}
