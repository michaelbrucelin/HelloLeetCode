using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0149
{
    public class Solution0149 : Interface0149
    {
        /// <summary>
        /// 暴力解
        /// 大概率会TLE，先写出来，再想怎样优化
        /// 用直线的 斜率+截距 来表示一条直线，为了精确，二者的值都用 (x,y) 表示，其中 x >=0, x y 互质，这样避免 x/y 无法精确表示的问题
        /// 已知两个点：(x1,y1), (x2,y2)
        ///     如果x1=x2, 斜率 (0, 0)         截距 x1
        ///     否则       斜率 (y2-y1, x2-x1) 截距 (x2y1-x1y2, x2-x1)
        /// 
        /// 提交竟然通过了... ...
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public int MaxPoints(int[][] points)
        {
            if (points.Length < 3) return points.Length;

            int result = 2, n = points.Length, _n = points.Length >> 1;
            Dictionary<(int, int, int, int), int> map = new Dictionary<(int, int, int, int), int>();
            (int, int, int, int) line; int cnt;
            for (int i = 0; i < n; i++) for (int j = i + 1; j < n; j++)
                {
                    line = GetLine(points[i][0], points[i][1], points[j][0], points[j][1]);
                    if (map.ContainsKey(line)) continue;
                    cnt = 2;
                    for (int k = j + 1; k < n; k++) if (GetLine(points[i][0], points[i][1], points[k][0], points[k][1]) == line) cnt++;
                    if (cnt > _n) return cnt;
                    map.Add(line, cnt);
                    result = Math.Max(result, cnt);
                }

            return result;

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

        /// <summary>
        /// 逻辑完全同MaxPoints()，只是将字典改成了集合，因为不需要计数
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public int MaxPoints2(int[][] points)
        {
            if (points.Length < 3) return points.Length;

            int result = 2, n = points.Length, _n = points.Length >> 1;
            HashSet<(int, int, int, int)> set = new HashSet<(int, int, int, int)>();
            (int, int, int, int) line; int cnt;
            for (int i = 0; i < n; i++) for (int j = i + 1; j < n; j++)
                {
                    line = GetLine(points[i][0], points[i][1], points[j][0], points[j][1]);
                    if (set.Contains(line)) continue;
                    cnt = 2;
                    for (int k = j + 1; k < n; k++) if (GetLine(points[i][0], points[i][1], points[k][0], points[k][1]) == line) cnt++;
                    if (cnt > _n) return cnt;
                    set.Add(line);
                    result = Math.Max(result, cnt);
                }

            return result;

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
