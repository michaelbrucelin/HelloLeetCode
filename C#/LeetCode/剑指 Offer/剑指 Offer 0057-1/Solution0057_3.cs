using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.剑指_Offer.剑指_Offer_0057_1
{
    public class Solution0057_3 : Interface0057
    {
        /// <summary>
        /// 双指针
        /// 1. 使用左右两个指针，分别指向数组的两端
        /// 2. 固定左指针，右指针向左移动，如果找到解，return，如果没有解，右指针停留在第一个使得左右指针和小于target的位置
        /// 3. 左指针右移，重复上一步骤
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] TwoSum(int[] nums, int target)
        {
            int left = 0, right = nums.Length - 1;
            while (left < right)
            {
                while (right > left)
                {
                    if (nums[left] + nums[right] == target) return new int[] { nums[left], nums[right] };
                    if (nums[left] + nums[right] < target) break;
                    right--;
                }
                left++;
            }

            return null;
        }
    }
}
