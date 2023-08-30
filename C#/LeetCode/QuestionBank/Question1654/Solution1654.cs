using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1654
{
    public class Solution1654 : Interface1654
    {
        public int MinimumJumps(int[] forbidden, int a, int b, int x)
        {
            if (x == 0) return 0;
            if (x % GetGCD(a, b) != 0) return -1;  // 裴蜀定理

            throw new NotImplementedException();
        }

        private int GetGCD(int x, int y)
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
