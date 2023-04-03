using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2367
{
    public class Solution2367_2 : Interface2367
    {
        /// <summary>
        /// 二分法
        /// 暴力二分法
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="diff"></param>
        /// <returns></returns>
        public int ArithmeticTriplets(int[] nums, int diff)
        {
            int result = 0, len = nums.Length, j, k;
            for (int i = 0; i < len; i++)
            {
                if ((j = BinarySearch(nums, i + 1, len - 1, nums[i] + diff)) == -1) continue;
                if ((k = BinarySearch(nums, j + 1, len - 1, nums[j] + diff)) == -1) continue;
                result++;
            }

            return result;
        }

        /// <summary>
        /// 二分法
        /// 充分利用严格递增这个特性
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="diff"></param>
        /// <returns></returns>
        public int ArithmeticTriplets2(int[] nums, int diff)
        {
            int result = 0, len = nums.Length, j, k;
            for (int i = 0; i < len - 2; i++)
            {
                if ((j = BinarySearch(nums, i + 1, Math.Min(i + diff, len - 1), nums[i] + diff)) == -1) continue;
                if ((k = BinarySearch(nums, j + 1, Math.Min(j + diff, len - 1), nums[j] + diff)) == -1) continue;
                result++;
            }

            return result;
        }

        private int BinarySearch(int[] nums, int left, int right, int target)
        {
            int mid; while (left <= right)
            {
                mid = left + ((right - left) >> 1);
                if (nums[mid] < target) left = mid + 1;
                else if (nums[mid] > target) right = mid - 1;
                else return mid;
            }

            return -1;
        }

        /// <summary>
        /// 二分法
        /// 充分利用严格递增这个特性，相当于Solution2367_5.md（三指针）的升级版
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="diff"></param>
        /// <returns></returns>
        public int ArithmeticTriplets3(int[] nums, int diff)
        {
            int result = 0, len = nums.Length, j = 1, k = 2, left;
            for (int i = 0; i < len - 2; i++)
            {
                left = Math.Max(i + 1, j);
                j = BinarySearch3(nums, left, Math.Min(left + diff, len - 1), nums[i] + diff);
                if (j == len) break;
                left = Math.Max(j + 1, k);
                k = BinarySearch3(nums, left, Math.Min(left + diff, len - 1), nums[j] + diff);
                if (k == len) break;

                if (nums[j] - nums[i] == diff && nums[k] - nums[j] == diff) result++;
            }

            return result;
        }

        /// <summary>
        /// 返回小于等于目标值的最后一个索引
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        private int BinarySearch3(int[] nums, int left, int right, int target)
        {
            int result = left, mid;
            while (left <= right)
            {
                mid = left + ((right - left) >> 1);
                if (nums[mid] <= target)
                {
                    result = mid; left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return result;
        }
    }
}
