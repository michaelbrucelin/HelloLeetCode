using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3379
{
    public class Solution3379 : Interface3379
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] ConstructTransformedArray(int[] nums)
        {
            int len = nums.Length;
            int[] result = new int[len];
            for (int i = 0, idx; i < len; i++)
            {
                idx = nums[i] % len + i;
                if (idx >= len) idx -= len; else if (idx < 0) idx += len;
                result[i] = nums[idx];
            }

            return result;
        }

        public int[] ConstructTransformedArray2(int[] nums)
        {
            int len = nums.Length;
            int[] result = new int[len];
            for (int i = 0, idx; i < len; i++)
            {
                idx = nums[i] % len + i;
                // if (idx >= len) idx -= len; else if (idx < 0) idx += len;
                idx = (idx + len) % len;
                result[i] = nums[idx];
            }

            return result;
        }
    }
}
