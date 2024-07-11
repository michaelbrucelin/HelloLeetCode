using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2972
{
    public class Solution2972_2 : Interface2972
    {
        /// <summary>
        /// 二分，排列组合
        /// 逻辑同Solution2972，只是将其中的双指针改为了二分法，没有太大的意义，写着玩的
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public long IncremovableSubarrayCount(int[] nums)
        {
            if (nums.Length == 1) return 1;

            int bl = 0, br = nums.Length - 1, len = nums.Length;
            while (bl < br && nums[bl] < nums[bl + 1]) bl++;      // 前缀数组
            if (bl == br) return len * (len + 1) >> 1;
            while (nums[br] > nums[br - 1]) br--;                 // 后缀数组

            long result = len - br + 1;                           // 前缀数组全部删除
            int pl = -1, pr;
            while (++pl <= bl)
            {
                pr = BinarySearch(nums, br, len - 1, nums[pl]);
                if (pr == len)
                {
                    result += bl - pl + 1;
                    break;
                }
                else
                {
                    result += len - pr + 1;
                    br = pr;
                }
            }

            return result;

            int BinarySearch(int[] nums, int left, int right, int target)
            {
                int result = right + 1, mid;
                while (left <= right)
                {
                    mid = left + ((right - left) >> 1);
                    if (nums[mid] > target)
                    {
                        result = mid; right = mid - 1;
                    }
                    else
                    {
                        left = mid + 1;
                    }
                }

                return result;
            }
        }
    }
}
