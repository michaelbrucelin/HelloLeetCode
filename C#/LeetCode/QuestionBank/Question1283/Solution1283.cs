using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1283
{
    public class Solution1283 : Interface1283
    {
        /// <summary>
        /// 二分
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="threshold"></param>
        /// <returns></returns>
        public int SmallestDivisor(int[] nums, int threshold)
        {
            int result = -1, low = 1, high = -1, mid, len = nums.Length;
            long sum = 0;
            for (int i = 0; i < len; i++) { high = Math.Max(high, nums[i]); sum += nums[i]; }
            if (threshold >= sum) return 1;
            while (low <= high)
            {
                mid = low + ((high - low) >> 1);
                if (check(nums, threshold, mid))
                {
                    result = mid; high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }

            return result;

            bool check(int[] nums, int threshold, int x)
            {
                int sum = 0, len = nums.Length;
                for (int i = 0; i < len; i++) if ((sum += (nums[i] + x - 1) / x) > threshold) return false;

                return true;
            }
        }
    }
}
