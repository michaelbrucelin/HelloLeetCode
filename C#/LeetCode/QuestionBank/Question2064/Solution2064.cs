using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2064
{
    public class Solution2064 : Interface2064
    {
        /// <summary>
        /// 二分
        /// </summary>
        /// <param name="n"></param>
        /// <param name="quantities"></param>
        /// <returns></returns>
        public int MinimizedMaximum(int n, int[] quantities)
        {
            int max = quantities[0]; long sum = quantities[0], len = quantities.Length;
            for (int i = 1; i < len; i++) { max = Math.Max(max, quantities[i]); sum += quantities[i]; }
            if (sum <= n) return 1;

            int result = max, cnt, low = 1, high = max, mid;
            while (low <= high)
            {
                mid = low + ((high - low) >> 1);
                cnt = 0;
                for (int i = 0; i < len; i++) if ((cnt += (quantities[i] + mid - 1) / mid) > n) break;
                if (cnt <= n)
                {
                    result = mid; high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }

            return result;
        }
    }
}
