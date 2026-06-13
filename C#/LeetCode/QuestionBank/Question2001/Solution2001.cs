using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2001
{
    public class Solution2001 : Interface2001
    {
        /// <summary>
        /// hash
        /// 使用最大公约数约分后分组
        /// </summary>
        /// <param name="rectangles"></param>
        /// <returns></returns>
        public long InterchangeableRectangles(int[][] rectangles)
        {
            long result = 0;
            Dictionary<(int, int), int> map = new Dictionary<(int, int), int>();
            int gcd, x, y;
            foreach (int[] rec in rectangles)
            {
                gcd = GetGCD(rec[0], rec[1]);
                x = rec[0] / gcd; y = rec[1] / gcd;
                if (map.TryGetValue((x, y), out int cnt)) map[(x, y)]++; else map.Add((x, y), 1);
            }

            foreach (int cnt in map.Values) result += 1L * cnt * (cnt - 1) >> 1;
            return result;

            static int GetGCD(int x, int y)
            {
                if (x == y) return x;

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
