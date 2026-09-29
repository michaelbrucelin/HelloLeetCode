using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2155
{
    public class Solution2155 : Interface2155
    {
        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<int> MaxScoreIndices(int[] nums)
        {
            IList<int> result = new List<int>();
            int max, cnt0 = 0, cnt1 = 0, len = nums.Length;
            for (int i = 0; i < len; i++) cnt1 += nums[i];
            max = cnt1;
            result.Add(0);
            for (int i = 0; i < len; i++)
            {
                cnt0 += 1 - nums[i];
                cnt1 -= nums[i];
                if (cnt0 + cnt1 < max) continue;
                if (cnt0 + cnt1 > max) { result.Clear(); max = cnt0 + cnt1; }
                result.Add(i + 1);
            }

            return result;
        }
    }
}
