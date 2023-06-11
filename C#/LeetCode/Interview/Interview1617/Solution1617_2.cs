using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview1617
{
    public class Solution1617_2 : Interface1617
    {
        /// <summary>
        /// 逐步消减
        /// 下面以[-2,  1, -3,  4, -1,  2,  1, -5, 4]为例
        /// 1. 将连续的正整数、负整数合并，0舍弃
        ///     [-2,  1, -3,  4, -1,  3, -5,  4]
        /// 2. 如果存在连续的三个值，满足两边的正整数都大于等于中间的负数，就把这3个整数合并
        ///     重复这一步，直到不存在这样的组合
        /// 3. 遍历一次，其中最大的数就是结果
        /// 
        /// 没时间写了，有时间再说
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaxSubArray(int[] nums)
        {
            List<int> list = new List<int>();
            int ptr = -1, len = nums.Length, sign = 1, sum = 0;
            while (++ptr < len)
            {
                if (nums[ptr] == 0) continue;
                if (Math.Sign(nums[ptr]) == sign)
                {
                    sum += nums[ptr];
                }
                else
                {
                    list.Add(sum); sign *= -1; sum = nums[ptr];
                }
            }
            list.Add(sum);
            if (list[0] == 0) list.RemoveAt(0);

            throw new NotImplementedException();
        }
    }
}
