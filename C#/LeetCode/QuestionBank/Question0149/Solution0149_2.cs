using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0149
{
    public class Solution0149_2 : Interface0149
    {
        /// <summary>
        /// 逻辑同Solution0149，枚举所有两点的可能性，并计数就可以了
        /// 如果结果为x，这样计算出来的是x(x-1)，结果就是Ceiling(Sqrt(x(x-1)))
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public int MaxPoints(int[][] points)
        {
            if (points.Length < 3) return points.Length;

            int result = 2, n = points.Length, _n = points.Length >> 1;
            Dictionary<(int, int, int, int), int> map = new Dictionary<(int, int, int, int), int>();
            (int, int, int, int) line;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    line = GetLine(points[i][0], points[i][1], points[j][0], points[j][1]);
                    if (map.ContainsKey(line)) map[line]++; else map.Add(line, 1);
                }
                for (int j = i + 1; j < n; j++)
                {
                    line = GetLine(points[i][0], points[i][1], points[j][0], points[j][1]);
                    if (map.ContainsKey(line)) map[line]++; else map.Add(line, 1);
                }
            }

            foreach (int val in map.Values) result = Math.Max(result, val);
            return (int)Math.Ceiling(Math.Sqrt(result));

            static (int, int, int, int) GetLine(int x1, int y1, int x2, int y2)
            {
                if (x1 == x2) return (0, 0, x1, 1);
                if (y1 == y2) return (0, 1, y1, 1);
                // y = ax + b
                var a = Simplify(y2 - y1, x2 - x1);
                var b = Simplify(x2 * y1 - x1 * y2, x2 - x1);

                return (a.Item1, a.Item2, b.Item1, b.Item2);
            }

            static (int, int) Simplify(int x, int y)
            {
                if (x == 0 || y == 0) return (0, 0);
                if (x < 0) { x *= -1; y *= -1; }
                int gcd = GetGCD(x, y);

                return (x / gcd, y / gcd);
            }

            static int GetGCD(int x, int y)
            {
                if (x == y) return x;
                if (y < 0) y *= -1;
                int move = 0;
                while (x != y) switch ((x & 1, y & 1))
                    {
                        case (0, 0): x >>= 1; y >>= 1; move++; break;
                        case (0, 1): x >>= 1; break;
                        case (1, 0): y >>= 1; break;
                        default:  // (1, 1)
                            if (x > y) x = (x - y) >> 1; else y = (y - x) >> 1;
                            break;
                    }

                return x << move;
            }
        }
    }
}
