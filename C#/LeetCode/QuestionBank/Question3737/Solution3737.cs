using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3737
{
    public class Solution3737 : Interface3737
    {
        /// <summary>
        /// 暴力
        /// 借助前缀和优化
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int CountMajoritySubarrays(int[] nums, int target)
        {
            int result = 0, len = nums.Length;
            int[] cnts = new int[len + 1];
            for (int i = 0; i < len; i++) cnts[i + 1] = cnts[i] + (nums[i] != target ? 0 : 1);

            for (int i = 0; i < len; i++) for (int j = i; j < len; j++) if (cnts[j + 1] - cnts[i] > ((j - i + 1) >> 1)) result++;
            return result;
        }
    }
}
