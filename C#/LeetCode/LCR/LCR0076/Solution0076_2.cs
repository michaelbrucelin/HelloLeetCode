using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0076
{
    public class Solution0076_2 : Interface0076
    {
        /// <summary>
        /// 快速选择
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int FindKthLargest(int[] nums, int k)
        {
            if (k == 1) return nums.Max();
            if (nums.Length == k) return nums.Min();

            shuffle();
            k = nums.Length - k;
            int p, lo = 0, hi = nums.Length - 1;
            while ((p = partition(lo, hi)) != k) if (p < k) lo = p + 1; else hi = p - 1;

            return nums[k];

            int partition(int lo, int hi)
            {
                if (lo == hi) return lo;

                int v = nums[lo], t, i = lo, j = hi + 1;
                while (true)
                {
                    while (nums[++i] < v) if (i == hi) break;
                    while (nums[--j] > v) ;
                    if (i >= j) break;
                    t = nums[i]; nums[i] = nums[j]; nums[j] = t;
                }
                nums[lo] = nums[j]; nums[j] = v;

                return j;
            }

            void shuffle()
            {
                Random random = new Random();
                for (int i = nums.Length - 1, j, t; i > 0; i--)
                {
                    j = random.Next(0, i + 1);
                    t = nums[i]; nums[i] = nums[j]; nums[j] = t;
                }
            }
        }
    }
}
