using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1760
{
    public class Solution1760_2 : Interface1760
    {
        /// <summary>
        /// 二分法
        /// 假定数组有n项，和为sum，最大值为max，最多操作k次，则理论上最好的结果是sum/(n+k)，最坏的结果是max
        /// 所以在sum/(n+k)和max之间进行二分查找即可
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="maxOperations"></param>
        /// <returns></returns>
        public int MinimumSize(int[] nums, int maxOperations)
        {
            int result = -1, sum = 0, max = -1, len = nums.Length;
            for (int i = 0; i < len; i++) { sum += nums[i]; max = Math.Max(max, nums[i]); }
            Array.Sort(nums);

            int low = (int)Math.Ceiling((double)sum / (len + maxOperations)), high = max, mid;
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
                int count = 0;
                for (int i = len - 1; i >= 0 && nums[i] > x; i--)
                {
                    count += (nums[i] - 1) / x;
                    if (count > maxOperations) return false;
                }

                return true;
            }
        }

        /// <summary>
        /// 逻辑完全同MinimumSize()，只是没有对数组排序，这样check()中需要验证数组中的所有项
        /// 对于LC上的测试用例，这样更快
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="maxOperations"></param>
        /// <returns></returns>
        public int MinimumSize2(int[] nums, int maxOperations)
        {
            int result = -1, sum = 0, max = -1, len = nums.Length;
            for (int i = 0; i < len; i++) { sum += nums[i]; max = Math.Max(max, nums[i]); }

            int low = (int)Math.Ceiling((double)sum / (len + maxOperations)), high = max, mid;
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
                int count = 0;
                for (int i = len - 1; i >= 0; i--) if (nums[i] > x)
                    {
                        count += (nums[i] - 1) / x;
                        if (count > maxOperations) return false;
                    }

                return true;
            }
        }
    }
}
