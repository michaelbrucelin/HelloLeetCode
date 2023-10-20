using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1005
{
    public class Solution1005 : Interface1005
    {
        /// <summary>
        /// 排序 + 贪心
        /// 假设数组中有n个负数
        /// 如果k <= n，那么只需要将最小的k个负数翻转即可
        /// 如果k >  n，令m = k - n
        ///     如果m是偶数，将全部的负数翻转即可
        ///     如果m是奇数，将全部的负数翻转后，将最小的元素再翻转一次
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int LargestSumAfterKNegations(int[] nums, int k)
        {
            Array.Sort(nums);

            int i = 0, len = nums.Length;
            for (; i < len && k > 0; i++, k--)
            {
                if (nums[i] < 0) nums[i] = -nums[i]; else break;
            }
            if (k > 0 && (k & 1) != 0)
            {
                if (i < len && i > 0)
                {
                    if (nums[i - 1] < nums[i]) nums[i - 1] = -nums[i - 1]; else nums[i] = -nums[i];
                }
                else if (i < len)
                {
                    nums[i] = -nums[i];
                }
                else  //  if (i < len)
                {
                    nums[i - 1] = -nums[i - 1];
                }
            }

            return nums.Sum();
        }
    }
}
