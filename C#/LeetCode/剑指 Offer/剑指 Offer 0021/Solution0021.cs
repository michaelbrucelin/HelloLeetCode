using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.剑指_Offer.剑指_Offer_0021
{
    public class Solution0021 : Interface0021
    {
        /// <summary>
        /// 构建新数组
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] Exchange(int[] nums)
        {
            int len = nums.Length; int left = 0, right = len - 1;
            int[] result = new int[len];
            for (int i = 0; i < len; i++)
            {
                if ((nums[i] & 1) != 0) result[left++] = nums[i]; else result[right--] = nums[i];
            }

            return result;
        }

        /// <summary>
        /// 双指针，原地更改
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] Exchange2(int[] nums)
        {
            int left = 0, right = nums.Length - 1;
            while (left < right)
            {
                while (left < right && (nums[left] & 1) == 1) left++;
                while (right > left && (nums[right] & 1) == 0) right--;
                if (left < right)
                {
                    Swap(nums, left++, right--);
                }
            }

            return nums;
        }

        private void Swap(int[] nums, int i, int j)
        {
            int t = nums[i]; nums[i] = nums[j]; nums[j] = t;
        }

        /// <summary>
        /// API
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] Exchange3(int[] nums)
        {
            Array.Sort(nums, new Comparison<int>((i1, i2) => (i2 & 1).CompareTo(i1 & 1)));
            return nums;
        }
    }
}
