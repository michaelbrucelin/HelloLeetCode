using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3658
{
    public class Solution3658 : Interface3658
    {
        /// <summary>
        /// 数学
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int GcdOfOddEvenSums(int n)
        {
            int odd = n * n;
            int even = odd + n;

            return GetGCD(odd, even);

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

        /// <summary>
        /// 数学
        /// 逻辑完全同GcdOfOddEvenSums()，仔细分析就是求 n*n 与 n*(n+1) 的GCD
        ///     消掉 n 后，求的是 n 与 n+1 的GCD，显然GCD为 1（反证法），所以结果为n
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int GcdOfOddEvenSums2(int n)
        {
            return n;
        }
    }
}
