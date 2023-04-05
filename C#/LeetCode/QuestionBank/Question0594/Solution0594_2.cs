using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0594
{
    public class Solution0594_2 : Interface0594
    {
        /// <summary>
        /// 排序 + 三指针
        /// ptr1指向某个元素第一次出现的位置
        /// ptr2指向下一个元素第一次出现的位置
        /// ptr3指向下下个元素第一次出现的位置
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindLHS(int[] nums)
        {
            Array.Sort(nums);
            int result = 0, len = nums.Length, ptr1 = 0, ptr2 = 0, ptr3;
            while (ptr1 < len)
            {
                while (ptr2 + 1 < len && nums[ptr2 + 1] == nums[ptr1]) ptr2++;
                if (nums[ptr2] == nums[ptr1]) ptr2++;
                if (ptr2 >= len) break;
                if (nums[ptr2] == nums[ptr1] + 1)
                {
                    ptr3 = ptr2; while (ptr3 + 1 < len && nums[ptr3 + 1] == nums[ptr2]) ptr3++;
                    result = Math.Max(result, ptr3 - ptr1 + 1);
                    ptr3++;
                    if (ptr3 >= len) break;
                    ptr1 = ptr2; ptr2 = ptr3;
                }
                else
                {
                    ptr1 = ptr2;
                }
            }

            return result;
        }

        /// <summary>
        /// 排序 + 三指针 + 二分查找
        /// ptr1指向某个元素第一次出现的位置
        /// ptr2指向下一个元素第一次出现的位置
        /// ptr3指向下下个元素第一次出现的位置
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindLHS2(int[] nums)
        {
            Array.Sort(nums);
            int result = 0, len = nums.Length, ptr1 = 0, ptr2 = 0, ptr3;
            while (ptr1 < len)
            {
                if (ptr2 == ptr1) ptr2 = BinarySearch(nums, ptr1 + 1, nums[ptr1] + 1);
                if (ptr2 >= len) break;
                if (nums[ptr2] == nums[ptr1] + 1)
                {
                    ptr3 = BinarySearch(nums, ptr2 + 1, nums[ptr2] + 1);
                    result = Math.Max(result, ptr3 - ptr1);
                    if (ptr3 >= len) break;
                    ptr1 = ptr2; ptr2 = ptr3;
                }
                else
                {
                    ptr1 = ptr2;
                }
            }

            return result;
        }

        /// <summary>
        /// 查找第一个大于等于目标的值的索引
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="left"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        private int BinarySearch(int[] nums, int left, int target)
        {
            int result = nums.Length, right = nums.Length - 1, mid;
            while (left <= right)
            {
                mid = left + ((right - left) >> 1);
                if (nums[mid] >= target)
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
