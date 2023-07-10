using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0016
{
    public class Solution0016_2 : Interface0016
    {
        /// <summary>
        /// 排序，2层循环 + 二分查找
        /// 两层循环遍历所有前两个值的可能性，然后二分查找适合的第三个值
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int ThreeSumClosest(int[] nums, int target)
        {
            if (nums.Length == 3) return nums.Sum();

            Array.Sort(nums);
            int result = nums[0] + nums[1] + nums[2], len = nums.Length;
            if (result == target) return result;
            for (int i = 0; i < len - 2; i++) for (int j = i + 1; j < len - 1; j++)
                {
                    int target3 = target - nums[i] - nums[j];
                    int left = SearchLeftBorder(nums, j + 1, len - 1, target3, true);
                    int right = SearchRightBorder(nums, j + 1, len - 1, target3, true);
                    int num3;
                    if (left < j + 1) num3 = nums[j + 1];
                    else if (right > len - 1) num3 = nums[len - 1];
                    else num3 = Math.Abs(nums[left] - target3) <= Math.Abs(nums[right] - target3) ? nums[left] : nums[right];

                    if (Math.Abs(num3 - target3) < Math.Abs(result - target))
                    {
                        result = nums[i] + nums[j] + num3;
                        if (result == target) goto Found;
                    }
                }
            Found:
            return result;
        }

        private int SearchLeftBorder(int[] arr, int left, int right, int target, bool equal)
        {
            int result = left - 1;
            while (left <= right)
            {
                int mid = left + ((right - left) >> 1);
                if (arr[mid] < target || (equal && arr[mid] <= target))
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

        private int SearchRightBorder(int[] arr, int left, int right, int target, bool equal)
        {
            int result = right + 1;
            while (left <= right)
            {
                int mid = left + ((right - left) >> 1);
                if (arr[mid] > target || (equal && arr[mid] >= target))
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
