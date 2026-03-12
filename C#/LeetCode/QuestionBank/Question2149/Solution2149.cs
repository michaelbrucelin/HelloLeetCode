using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2149
{
    public class Solution2149 : Interface2149
    {
        /// <summary>
        /// 模拟，双指针
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] RearrangeArray(int[] nums)
        {
            int len = nums.Length;
            int[] result = new int[len];
            int p0 = -2, p1 = -1;
            for (int i = 0, num; i < len; i++) switch (num = nums[i])
                {
                    case > 0: result[p0 += 2] = num; break;
                    case < 0: result[p1 += 2] = num; break;
                    default: break;
                }

            return result;
        }

        /// <summary>
        /// 逻辑同RearrangeArray()，搞点小技巧
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] RearrangeArray2(int[] nums)
        {
            int len = nums.Length;
            int[] result = new int[len];
            int[] ids = [-2, -1];
            for (int i = 0, num; i < len; i++) result[ids[(num = nums[i]) >>> 31] += 2] = num;

            return result;
        }
    }
}
