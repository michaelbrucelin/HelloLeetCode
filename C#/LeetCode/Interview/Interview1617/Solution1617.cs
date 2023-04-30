using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview1617
{
    public class Solution1617 : Interface1617
    {
        /// <summary>
        /// 前缀和
        /// 下面以[-2,  1, -3,  4, -1,  2,  1, -5, 4]为例
        /// 1. 计算数组的前缀和
        ///     [0, -2, -1, -4,  0, -1,  1,  2, -3, 1]
        /// 2. 这是就变成了找两个位置使其差最大
        ///     如果后面的元素大于等于当前的元素，计算二者的差，即一个可能的结果
        ///     如果后面的元素小于当前的元素，从后面的元素开始重新统计
        ///     [0, -2, -1, -4,  0, -1,  1,  2, -3, 1]
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaxSubArray(int[] nums)
        {
            int len = nums.Length;
            int[] pre = new int[len + 1];
            for (int i = 0; i < len; i++) pre[i + 1] = pre[i] + nums[i];

            int result = nums[0];
            for (int i = 1, left = 0; i <= len; i++)
            {
                result = Math.Max(result, pre[i] - left);
                if (pre[i] < left) left = pre[i];
            }

            return result;
        }
    }
}
