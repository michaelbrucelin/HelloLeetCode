using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1911
{
    public class Solution1911 : Interface1911
    {
        /// <summary>
        /// 分析
        /// 1. 数组前补一项0
        ///     6 2 1 2 4 5  -> 0 6 2 1 2 4 5
        /// 2. 从前向后遍历，只要元素不小于前面的元素，就向后移动，如果小于前面的元素，就重新计算
        ///     0 6 2 1 2 4 5
        ///     6比0大，继续向后
        ///     2比6小，那么找到了一组0 6，从2继续向后找
        ///     1比2小，从1继续向后找
        ///     2比1大，继续向后
        ///     4比2大，继续向后
        ///     5比4大，继续向后，到达数组末端，找到一组1 5
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public long MaxAlternatingSum(int[] nums)
        {
            long result = 0;
            int l = 0, r = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] >= r)
                {
                    r = nums[i];
                }
                else
                {
                    result += r - l; l = r = nums[i];
                }
            }
            result += r - l;

            return result;
        }
    }
}
