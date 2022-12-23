using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1753
{
    public class Solution1753_2 : Interface1753
    {
        /// <summary>
        /// 数学规律，可以建立公式，见Solution1753_2.md
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public int MaximumScore(int a, int b, int c)
        {
            int t;
            if (a > b) { t = a; a = b; b = t; }
            if (b > c) { t = b; b = c; c = t; }
            if (a > b) { t = a; a = b; b = t; }  // a <= b <= c

            if (a == b && b == c)
            {
                if ((a & 1) != 1) return a / 2 * 3; else return a / 2 * 3 + 1;
            }
            else if (a == b && b < c)
            {
                if (c >= (a << 1))
                {
                    return a * 2;
                }
                else  // if (c < (a >> 1))
                {
                    if (((a * 2 - c) & 1) != 1)
                        return (c - a) * 2 + (a * 2 - c) / 2 * 3;
                    else
                        return (c - a) * 2 + (a * 2 - c) / 2 * 3 + 1;
                }
            }
            else if (a < b && b == c)
            {
                if ((a & 1) != 1) return b - a + a / 2 * 3; else return b - a + a / 2 * 3 + 1;
            }
            else  // if (a < b && b < c)
            {
                if (c >= a + b)
                {
                    return b - a + a * 2;
                }
                else  // if (c < a + b)
                {
                    if (((a + b - c) & 1) != 1)
                        return c * 2 - a - b + (a + b - c) / 2 * 3;
                    else
                        return c * 2 - a - b + (a + b - c) / 2 * 3 + 1;
                }
            }
        }
    }
}
