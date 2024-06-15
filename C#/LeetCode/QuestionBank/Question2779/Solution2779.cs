using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2779
{
    public class Solution2779 : Interface2779
    {
        /// <summary>
        /// 排序 + 二分
        /// 遍历每一个元素num，以其为序列的第一个元素，找出最后一个 <= num+k+k 的元素
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MaximumBeauty(int[] nums, int k)
        {
            Array.Sort(nums);
            int result = 0, id, left, right, mid, len = nums.Length;
            k <<= 1;
            for (int i = 0; i < len - result; i++)
            {
                id = left = i; right = len - 1;
                while (left <= right)
                {
                    mid = left + ((right - left) >> 1);
                    if (nums[i] + k >= nums[mid])
                    {
                        id = mid; left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }
                result = Math.Max(result, id - i + 1);
            }

            return result;
        }

        /// <summary>
        /// 逻辑同MaximumBeauty()，稍加优化，下一次二分的起点是上一次二分的结果
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MaximumBeauty2(int[] nums, int k)
        {
            Array.Sort(nums);
            int result = 0, id = 0, left, right, mid, len = nums.Length;
            k <<= 1;
            for (int i = 0; i < len - result; i++)
            {
                left = id; id = i; right = len - 1;
                while (left <= right)
                {
                    mid = left + ((right - left) >> 1);
                    if (nums[i] + k >= nums[mid])
                    {
                        id = mid; left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }
                result = Math.Max(result, id - i + 1);
            }

            return result;
        }
    }
}
