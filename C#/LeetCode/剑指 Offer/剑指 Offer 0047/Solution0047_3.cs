using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.剑指_Offer.剑指_Offer_0047
{
    public class Solution0047_3 : Interface0047
    {
        /// <summary>
        /// 二进制枚举
        /// 一共一定走(rcnt-1) + (ccnt-1)步，即总步数：rcnt+ccnt-2，其中rcnt-1步向下走，所以这就是一个二进制枚举的问题
        /// 
        /// 逻辑是对的，但是题目的范围会导致整型溢出，所以没有提交测试，参考测试用例4（18行16列）
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int MaxValue(int[][] grid)
        {
            int rcnt = grid.Length, ccnt = grid[0].Length;
            if (rcnt == 1 || ccnt == 1) return grid.Sum(arr => arr.Sum());

            int result = 0, n = rcnt + ccnt - 2, k = rcnt - 1; int kset = (1 << k) - 1;
            while (kset < 1 << n)
            {
                int _result = grid[0][0]; for (int i = 0, r = 0, c = 0; i < n; i++)
                {
                    int dir = (kset >> i) & 1;
                    _result += grid[r += dir][c += 1 - dir];
                }
                result = Math.Max(result, _result);
                int x = kset & -kset, y = kset + x;
                kset = ((kset & ~y) / x >> 1) | y;
            }

            return result;
        }
    }
}
