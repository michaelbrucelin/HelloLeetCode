using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2540
{
    public class Solution2540 : Interface2540
    {
        /// <summary>
        /// 二分法
        /// 小表驱动大表
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public int GetCommon(int[] nums1, int[] nums2)
        {
            if (nums1[0] > nums2[^1] || nums2[0] > nums1[^1]) return -1;
            if (nums1.Length > nums2.Length)
            {
                int[] arr = nums1; nums1 = nums2; nums2 = arr;
            }
            for (int i = 0; i < nums1.Length; i++)
            {
                if (BinarySearch(nums2, nums1[i])) return nums1[i];
            }

            return -1;
        }

        private bool BinarySearch(int[] nums, int target)
        {
            int low = 0, high = nums.Length - 1, mid, val;
            while (low <= high)
            {
                val = nums[mid = low + ((high - low) >> 1)];
                if (val < target) low = mid + 1;
                else if (val > target) high = mid - 1;
                else return true;
            }

            return false;
        }
    }
}
