using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0079
{
    public class Solution0079_3 : Interface0079
    {
        /// <summary>
        /// 二进制枚举
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> Subsets(int[] nums)
        {
            IList<IList<int>> result = [];
            int n = 1 << nums.Length;
            for (int i = 0, mask, offset; i < n; i++)
            {
                result.Add([]);
                mask = i; offset = 0;
                while (mask > 0)
                {
                    if ((mask & 1) != 0) result[^1].Add(nums[offset]);
                    mask >>= 1; offset++;
                }
            }

            return result;
        }
    }
}
