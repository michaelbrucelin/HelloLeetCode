using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question4008
{
    public class Solution4008 : Interface4008
    {
        /// <summary>
        /// 差分 + 二分
        /// </summary>
        /// <param name="monsters"></param>
        /// <param name="boosts"></param>
        /// <returns></returns>
        public long MinInitialStrength(int[] monsters, int[][] boosts)
        {
            int len = monsters.Length;
            long[] diff = new long[len + 1];
            foreach (int[] boost in boosts) { diff[boost[0]] += boost[2]; diff[boost[1] + 1] -= boost[2]; }
            for (int i = 1; i < len; i++) diff[i] += diff[i - 1];

            long result = -1, low = 0, high = long.MaxValue, mid;
            while (low <= high)
            {
                mid = low + ((high - low) >> 1);
                if (check(monsters, diff, mid))
                {
                    result = mid; high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }

            return result;

            static bool check(int[] monsters, long[] boosts, long x)
            {
                int len = monsters.Length;
                for (int i = 0; i < len; i++)
                {
                    if (x + boosts[i] < monsters[i]) return false;
                    x -= monsters[i];
                    if (x < 0) x = 0;
                }

                return true;
            }
        }
    }
}
