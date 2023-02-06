using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0349
{
    public class Solution0349_3 : Interface0349
    {
        /// <summary>
        /// 排序 + 二分查找
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public int[] Intersection(int[] nums1, int[] nums2)
        {
            Array.Sort(nums1);
            Array.Sort(nums2);
            List<int> result = new List<int>();
            if (nums1.Length > nums2.Length)
            {
                int[] t = nums1; nums1 = nums2; nums2 = t;  // 小表驱动大表
            }

            int id = -1, len = nums1.Length, left = 0, right = nums2.Length - 1;
            while (++id < len)
            {
                while (id + 1 < len && nums1[id + 1] == nums1[id]) id++;
                var info = BinarySearch(nums2, left, right, nums1[id]);
                if (info.exists)
                {
                    result.Add(nums1[id]); left = info.id;
                }
            }

            return result.ToArray();
        }

        private (bool exists, int id) BinarySearch(int[] nums, int left, int right, int target)
        {
            int mid; while (left <= right)
            {
                mid = left + ((right - left) >> 1);
                if (nums[mid] == target)
                    return (true, mid);
                else if (nums[mid] < target)
                    left = mid + 1;
                else
                    right = mid - 1;
            }

            return (false, -1);
        }
    }
}
