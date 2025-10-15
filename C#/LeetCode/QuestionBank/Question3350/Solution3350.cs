using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3350
{
    public class Solution3350 : Interface3350
    {
        /// <summary>
        /// 遍历
        /// 逻辑同Solution3349
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaxIncreasingSubarrays(IList<int> nums)
        {
            int result = 0, len1 = 0, len2 = 1, cnt = nums.Count;
            for (int i = 1; i < cnt; i++)
            {
                if (nums[i] > nums[i - 1]) { len2++; continue; }
                result = Math.Max(result, Math.Min(len1, len2));
                result = Math.Max(result, len2 >> 1);
                len1 = len2;
                len2 = 1;
            }
            result = Math.Max(result, Math.Min(len1, len2));
            result = Math.Max(result, len2 >> 1);

            return result;
        }
    }
}
