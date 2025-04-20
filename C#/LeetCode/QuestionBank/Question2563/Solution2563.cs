using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2563
{
    public class Solution2563 : Interface2563
    {
        /// <summary>
        /// 排序 + 二分
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="lower"></param>
        /// <param name="upper"></param>
        /// <returns></returns>
        public long CountFairPairs(int[] nums, int lower, int upper)
        {
            Array.Sort(nums);
            long result = 0;
            int l = 0, r = nums.Length - 1, len = nums.Length;
            for (int i = 0; i < len; i++)
            {
                l = min_ge(i + 1, len - 1, lower - nums[i]);
                if (l == -1) continue;
                r = max_le(l, len - 1, upper - nums[i]);
                if (r == -1) continue;
                result += r - l + 1;
            }

            return result;

            int min_ge(int l, int r, int target)
            {
                int id = -1, mid;
                while (l <= r)
                {
                    mid = l + ((r - l) >> 1);
                    if (nums[mid] >= target)
                    {
                        id = mid; r = mid - 1;
                    }
                    else
                    {
                        l = mid + 1;
                    }
                }

                return id;
            }

            int max_le(int l, int r, int target)
            {
                int id = -1, mid;
                while (l <= r)
                {
                    mid = l + ((r - l) >> 1);
                    if (nums[mid] <= target)
                    {
                        id = mid; l = mid + 1;
                    }
                    else
                    {
                        r = mid - 1;
                    }
                }

                return id;
            }
        }
    }
}
