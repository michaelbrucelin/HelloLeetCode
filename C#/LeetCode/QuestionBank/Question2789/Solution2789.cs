using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2789
{
    public class Solution2789 : Interface2789
    {
        /// <summary>
        /// 贪心
        /// 从后向前遍历即可
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public long MaxArrayValue(int[] nums)
        {
            long result = nums[^1], _result = nums[^1];
            for (int i = nums.Length - 2; i >= 0; i--)
            {
                if (nums[i] <= _result)
                {
                    _result += nums[i];
                }
                else
                {
                    result = Math.Max(result, _result);
                    _result = nums[i];
                }
            }
            result = Math.Max(result, _result);

            return result;
        }

        /// <summary>
        /// 逻辑同MaxArrayValue()，略加优化，不需要比较result与_result的大小，_result一定更大
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public long MaxArrayValue2(int[] nums)
        {
            long result = nums[^1];
            for (int i = nums.Length - 2; i >= 0; i--)
            {
                if (nums[i] <= result) result += nums[i]; else result = nums[i];
            }

            return result;
        }
    }
}
