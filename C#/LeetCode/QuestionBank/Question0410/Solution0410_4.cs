using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0410
{
    public class Solution0410_4 : Interface0410
    {
        /// <summary>
        /// 二分
        /// 逻辑同官解
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int SplitArray(int[] nums, int k)
        {
            if (k == 1) return nums.Sum();
            if (k == nums.Length) return nums.Max();

            int result = -1, left = nums.Max(), right = nums.Sum(), mid;
            while (left <= right)
            {
                mid = left + ((right - left) >> 1);
                if (IsValid(nums, k, mid))
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

        private bool IsValid(int[] nums, int k, int target)
        {
            for (int i = 0, sum = 0; i < nums.Length; i++)
            {
                if ((sum += nums[i]) > target)
                {
                    sum = nums[i];
                    if (--k < 1) return false;
                }
            }

            return true;
        }
    }
}
