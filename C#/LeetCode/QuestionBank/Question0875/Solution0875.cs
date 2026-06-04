using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0875
{
    public class Solution0875 : Interface0875
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

            int result = max, hour, low = 1, high = max, mid;
            while (low <= high)
            {
                mid = low + ((high - low) >> 1);
                hour = 0;
                for (int i = 0; i < len; i++) if ((hour += (piles[i] + mid - 1) / mid) > h) break;
                if (hour > h) { low = mid + 1; } else { result = mid; high = mid - 1; }
            }

            return result;
        }
    }
}
