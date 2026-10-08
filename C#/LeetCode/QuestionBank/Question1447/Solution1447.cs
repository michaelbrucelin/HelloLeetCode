using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1447
{
    public class Solution1447 : Interface1447
    {
        /// <summary>
        /// 暴力查找
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public IList<string> SimplifiedFractions(int n)
        {
            if (n == 1) return [];

            List<string> result = [];
            for (int x = 2; x <= n; x++) for (int y = 1; y < x; y++)
                {
                    if (gcd(x, y) == 1) result.Add($"{y}/{x}");
                }

            return result;

            static int gcd(int x, int y)
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
