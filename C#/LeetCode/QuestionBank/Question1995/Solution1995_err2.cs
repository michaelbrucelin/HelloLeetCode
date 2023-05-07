using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1995
{
    public class Solution1995_err2 : Interface1995
    {
        /// <summary>
        /// 排序 + 二分查找
        /// 1. 排序
        /// 2. 前三个元素排列组合，第4个元素二分查找
        /// 
        /// 依然是错误解，排序之后就丢失了元素在原数组中的id
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int CountQuadruplets(int[] nums)
        {
            Array.Sort(nums);
            int result = 0, sum, len = nums.Length;
            for (int a = 0; a < len - 3; a++) for (int b = a + 1; b < len - 2; b++)
                {
                    sum = nums[a] + nums[b];
                    for (int c = b + 1; c < len - 1; c++)
                        result += BinarySearch(nums, c + 1, sum + nums[c]);
                }

            return result;
        }

        /// <summary>
        /// 找出数组中target的数量
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="start"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        private int BinarySearch(int[] nums, int start, int target)
        {
            int left = nums.Length, low = start, high = nums.Length - 1, mid;
            while (low <= high)  // 找出大于等于目标的最小坐标
            {
                mid = low + ((high - low) >> 1);
                if (nums[mid] >= target)
                {
                    left = mid; high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }
            if (left == nums.Length || nums[left] != target) return 0;
            int right = left; low = left; high = nums.Length - 1;
            while (low <= high)  // 找出等于目标的最大坐标
            {
                mid = low + ((high - low) >> 1);
                if (nums[mid] == target)
                {
                    right = mid; low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }

            return right - left + 1;
        }
    }
}
