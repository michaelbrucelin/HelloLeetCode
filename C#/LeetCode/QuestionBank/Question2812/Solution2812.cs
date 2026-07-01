using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2812
{
    public class Solution2812 : Interface2812
    {
        /// <summary>
        /// 二分
        /// 1. 先暴力填表，计算出每个位置的“安全系数”
        ///     题目就变成找出所有路径中最小值的最大值是多少
        /// 2. 二分
        ///     第一反应是DFS/DP，但是没想明白怎样DP，所以直接二分
        /// 
        /// 暴力填表的时间复杂度是O(n^3)，大概率会TLE，先写出来试试再想优化的事
        /// 逻辑没问题，意料之中的TLE，参考测试用例04
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int MaximumSafenessFactor(IList<IList<int>> grid)
        {
            if (grid[0][0] == 1 || grid[^1][^1] == 1 || grid.Count == 1) return 0;  // 题目限定至少有一个小偷

            int result = 0, n = grid.Count, N = n << 1, low = 0, high, mid;
            List<(int, int)> thief = new List<(int, int)>();
            for (int i = 0; i < n; i++) for (int j = 0; j < n; j++) if (grid[i][j] == 1) thief.Add((i, j));
            for (int i = 0; i < n; i++) for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == 1) { grid[i][j] = 0; continue; }
                    grid[i][j] = N;
                    foreach ((int _i, int _j) in thief) grid[i][j] = Math.Min(grid[i][j], Math.Abs(i - _i) + Math.Abs(j - _j));
                }
            high = Math.Min(grid[0][0], grid[^1][^1]);
            int[] dirs = [-1, 0, 1, 0, -1];
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
