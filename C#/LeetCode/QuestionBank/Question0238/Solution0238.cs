using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0238
{
    public class Solution0238 : Interface0238
    {
        /// <summary>
        /// 预处理
        /// 预处理前缀积与后缀积数组
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] ProductExceptSelf(int[] nums)
        {
            int len = nums.Length;
            int[] prefix = new int[len], suffix = new int[len];
            prefix[0] = nums[0];
            for (int i = 1; i < len - 1; i++) prefix[i] = prefix[i - 1] * nums[i];
            suffix[^1] = nums[^1];
            for (int i = len - 2; i > 0; i--) suffix[i] = suffix[i + 1] * nums[i];

            int[] result = new int[len];
            result[0] = suffix[1];
            result[^1] = prefix[^2];
            for (int i = 1; i < len - 1; i++) result[i] = prefix[i - 1] * suffix[i + 1];

            return result;
        }

        /// <summary>
        /// 进阶
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] ProductExceptSelf2(int[] nums)
        {
            int len = nums.Length;
            int[] result = new int[len];
            result[^1] = nums[^1];
            for (int i = len - 2; i > 0; i--) result[i] = result[i + 1] * nums[i];

            int pre = nums[0];
            result[0] = result[1];
            for (int i = 1; i < len - 1; i++)
            {
                result[i] = pre * result[i + 1];
                pre *= nums[i];
            }
            result[^1] = pre;

            return result;
        }
    }
}
