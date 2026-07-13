using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2013
{
    public class Solution2013
    {
    }

    public class DetectSquares
    {
        /// <summary>
        /// Hash
        /// </summary>
        public DetectSquares()
        {
            xpoints = new Dictionary<int, Dictionary<int, int>>();
            ypoints = new Dictionary<int, Dictionary<int, int>>();
            points = new Dictionary<(int, int), int>();
        }

        private Dictionary<int, Dictionary<int, int>> xpoints, ypoints;
        private Dictionary<(int, int), int> points;                      // 可是使用xpoints与ypoints代替points，这里为了对称性单独记录，无论是时间复杂度还是空间复杂度都只有坏处没有好处，只是强迫症...

        public void Add(int[] point)
        {
            int x = point[0], y = point[1];
            if (xpoints.TryGetValue(x, out Dictionary<int, int> ys)) { ys.TryAdd(y, 0); ys[y]++; } else xpoints.Add(x, new Dictionary<int, int>() { { y, 1 } });
            if (ypoints.TryGetValue(y, out Dictionary<int, int> xs)) { xs.TryAdd(x, 0); xs[x]++; } else ypoints.Add(y, new Dictionary<int, int>() { { x, 1 } });
            if (points.TryGetValue((x, y), out int cnt)) points[(x, y)] = ++cnt; else points.Add((x, y), 1);
        }

        public int Count(int[] point)
        {
            int result = 0, x = point[0], y = point[1], l;
            if (!xpoints.TryGetValue(x, out Dictionary<int, int> ys) || !ypoints.TryGetValue(y, out Dictionary<int, int> xs)) return 0;

            foreach (int _y in ys.Keys) if (_y != y)
                {
                    l = Math.Abs(y - _y);
                    if (xs.ContainsKey(x - l) && points.ContainsKey((x - l, _y))) result += ys[_y] * xs[x - l] * points[(x - l, _y)];
                    if (xs.ContainsKey(x + l) && points.ContainsKey((x + l, _y))) result += ys[_y] * xs[x + l] * points[(x + l, _y)];
                }

            return result;
        }
    }
}
