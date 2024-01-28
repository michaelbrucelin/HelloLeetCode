using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0365
{
    public class Solution0365 : Interface0365
    {
        /// <summary>
        /// 二元不定方程的整数解
        /// 本质上就是求方程 jug1Capacity * X + jug2Capacity * Y = targetCapacity 的整数解
        /// ax + by = c 有整数解的充要条件是 gcd(a, b) | c
        /// </summary>
        /// <param name="jug1Capacity"></param>
        /// <param name="jug2Capacity"></param>
        /// <param name="targetCapacity"></param>
        /// <returns></returns>
        public bool CanMeasureWater(int jug1Capacity, int jug2Capacity, int targetCapacity)
        {
            if (jug1Capacity + jug2Capacity < targetCapacity) return false;
            return targetCapacity % GetGCD(jug1Capacity, jug2Capacity) == 0;
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
