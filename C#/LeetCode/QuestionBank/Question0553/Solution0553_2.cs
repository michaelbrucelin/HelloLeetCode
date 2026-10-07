using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0553
{
    public class Solution0553_2 : Interface0553
    {
        /// <summary>
        /// 贪心
        /// 由于数组中每一项都大于1，所以结果一定是nums[0]/(nums[1]/nums[2]/.../nums[^1])
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public string OptimalDivision(int[] nums)
        {
            int len = nums.Length;
            if (len == 1) return nums[0].ToString();
            if (len == 2) return $"{nums[0]}/{nums[1]}";

            StringBuilder result = new StringBuilder();
            result.Append(nums[0]);
            result.Append("/(");
            result.Append(nums[1]);
            // result.Append(string.Join('/', nums, 1, len - 1));
            for (int i = 2; i < len; i++) { result.Append('/'); result.Append(nums[i]); }
            result.Append(')');

            return result.ToString();
        }
    }
}
