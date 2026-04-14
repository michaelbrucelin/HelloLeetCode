using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0592
{
    public class Solution0592 : Interface0592
    {
        /// <summary>
        /// 双指针
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public string FractionAddition(string expression)
        {
            int x = 0, y = 1, id = 0, sign = 1, p = -1, len = expression.Length;
            int[] xy = [0, 1];
            while (++p < len)
            {
                switch (expression[p])
                {
                    case '+':
                        (x, y) = FractionAddition(x, y, sign * xy[0], xy[1]);
                        id = 0; xy[0] = 0; sign = 1;
                        break;
                    case '-':
                        (x, y) = FractionAddition(x, y, sign * xy[0], xy[1]);
                        id = 0; xy[0] = 0; sign = -1;
                        break;
                    case '/':
                        id = 1; xy[1] = 0;
                        break;
                    default:    // 0-9
                        xy[id] = xy[id] * 10 + (expression[p] & 15);
                        break;
                }
            }
            (x, y) = FractionAddition(x, y, sign * xy[0], xy[1]);

            return $"{x}/{y}";

            static (int, int) FractionAddition(int x1, int y1, int x2, int y2)
            {
                (x1, y1) = Simplify(x1, y1);
                (x2, y2) = Simplify(x2, y2);

                int gcd = GetGCD(y1, y2);
                int x = y2 / gcd * x1 + y1 / gcd * x2;
                int y = x == 0 ? 1 : y1 / gcd * y2;

                return Simplify(x, y);
            }

            static (int, int) Simplify(int x, int y)
            {
                if (x == 0) return (0, 1);
                // if (y < 0) { x = -x; y = -y; }  // 题目限定，不允许
                int gcd = GetGCD(Math.Abs(x), y);

                return (x / gcd, y / gcd);
            }

            static int GetGCD(int x, int y)
            {
                if (x == y) return x;

                int move = 0;
                while (x != y)
                {
                    switch ((x & 1, y & 1))
                    {
                        case (0, 0): x >>= 1; y >>= 1; move++; break;
                        case (0, 1): x >>= 1; break;
                        case (1, 0): y >>= 1; break;
                        default:  // (1, 1)
                            if (x > y) x = (x - y) >> 1; else y = (y - x) >> 1;
                            break;
                    }
                }

                return x << move;
            }
        }
    }
}
