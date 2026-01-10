using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0858
{
    public class Solution0858_2 : Interface0858
    {
        /// <summary>
        /// 模拟，最小公倍数
        /// 逻辑同Solution0858，使用最小公倍数优化
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public int MirrorReflection(int p, int q)
        {
            int[][] result = [[1, 2], [0, -1]];
            int lcm = p * q / GetGCD(p, q);

            return result[(lcm / p - 1) & 1][(lcm / q - 1) & 1];

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
