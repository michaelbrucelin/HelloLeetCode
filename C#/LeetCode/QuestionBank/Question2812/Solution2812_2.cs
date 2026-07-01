using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2812
{
    public class Solution2812_2 : Interface2812
    {
        /// <summary>
        /// 二分 + 多源BFS
        /// 逻辑完全同Solution2812，将Solution2812中的暴力填表改为由thief BFS填写
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int MaximumSafenessFactor(IList<IList<int>> grid)
        {
            if (grid[0][0] == 1 || grid[^1][^1] == 1 || grid.Count == 1) return 0;  // 题目限定至少有一个小偷

            int result = 0, n = grid.Count, N = n << 1, low = 0, high, mid;
            List<(int, int)> thief = new List<(int, int)>();
            for (int i = 0; i < n; i++) for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == 1) thief.Add((i, j));
                    grid[i][j] = -1;
                }
            int[] dirs = [-1, 0, 1, 0, -1];
            Queue<(int, int)> queue = new Queue<(int, int)>();
            foreach (var item in thief) { queue.Enqueue(item); grid[item.Item1][item.Item2] = 0; }
            int r, c, _r, _c, step = 0;
            while (queue.Count > 0)
            {
                step++;
                for (int i = queue.Count; i > 0; i--)
                {
                    (r, c) = queue.Dequeue();
                    for (int j = 0; j < 4; j++)
                    {
                        _r = r + dirs[j]; _c = c + dirs[j + 1];
                        if (_r < 0 || _r >= n || _c < 0 || _c >= n || grid[_r][_c] != -1) continue;
                        grid[_r][_c] = step;
                        queue.Enqueue((_r, _c));
                    }
                }
            }
            high = Math.Min(grid[0][0], grid[^1][^1]);

            while (low <= high)
            {
                mid = low + ((high - low) >> 1);
                if (check(grid, n, mid, dirs)) { result = mid; low = mid + 1; } else high = mid - 1;
            }

            return result;

            static bool check(IList<IList<int>> grid, int n, int x, int[] dirs)
            {
                bool[,] visited = new bool[n, n];
                Queue<(int, int)> queue = new Queue<(int, int)>();
                queue.Enqueue((0, 0));
                int r, c, _r, _c;
                while (queue.Count > 0)
                {
                    (r, c) = queue.Dequeue();
                    if (visited[r, c]) continue; visited[r, c] = true;
                    for (int i = 0; i < 4; i++)
                    {
                        _r = r + dirs[i]; _c = c + dirs[i + 1];
                        if (_r < 0 || _r >= n || _c < 0 || _c >= n || grid[_r][_c] < x || visited[_r, _c]) continue;
                        if (_r == n - 1 && _c == n - 1) return true;
                        queue.Enqueue((_r, _c));
                    }
                }

                return false;
            }
        }
    }
}
