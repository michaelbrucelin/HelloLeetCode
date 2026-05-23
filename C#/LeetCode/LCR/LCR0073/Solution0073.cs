using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0073
{
    public class Solution0073 : Interface0073
    {
        /// <summary>
        /// 二分
        /// </summary>
        /// <param name="piles"></param>
        /// <param name="h"></param>
        /// <returns></returns>
        public int MinEatingSpeed(int[] piles, int h)
        {
            int max = piles[0], len = piles.Length;
            for (int i = 1; i < len; i++) max = Math.Max(max, piles[i]);

            int result = max, low = 1, high = max, mid;
            while (low <= high)
            {
                mid = low + ((high - low) >> 1);
                if (check(mid))
                {
                    result = mid; high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }

            return result;

            bool check(int x)
            {
                int _h = 0;
                for (int i = 0; i < len; i++) _h += (int)Math.Ceiling((double)piles[i] / x);
                return _h <= h;
            }
        }
    }
}
