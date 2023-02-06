using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0350
{
    public class Solution0350_3 : Interface0350
    {
        /// <summary>
        /// 排序 + 二分查找
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public int[] Intersect(int[] nums1, int[] nums2)
        {
            Array.Sort(nums1);
            Array.Sort(nums2);
            if (nums1.Length > nums2.Length) { var t = nums1; nums1 = nums2; nums2 = t; }  // 小表驱动大表

            List<int> result = new List<int>();
            int id = -1, len1 = nums1.Length, left = 0, right = nums2.Length - 1;
            while (++id < len1)
            {
                var info = BinarySearch(nums2, left, right, nums1[id]);
                if (info.exists)
                {
                    result.Add(nums1[id]); left = info.id + 1;
                }
                else
                {
                    while (id + 1 < len1 && nums1[id + 1] == nums1[id]) id++;
                }
            }

            return result.ToArray();
        }

        private (bool exists, int id) BinarySearch(int[] nums, int left, int right, int target)
        {
            (bool, int) result = (false, -1);

            int mid; while (left <= right)
            {
                mid = left + ((right - left) >> 1);
                if (nums[mid] == target)
                {
                    result = (true, mid); right = mid - 1;
                }
                else if (nums[mid] < target)
                    left = mid + 1;
                else
                    right = mid - 1;
            }

            return result;
        }
    }
}
