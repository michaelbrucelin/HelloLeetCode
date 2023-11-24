using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2824
{
    public class Solution2824 : Interface2824
    {
        /// <summary>
        /// 暴力枚举
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int CountPairs(IList<int> nums, int target)
        {
            int result = 0, cnt = nums.Count;
            for (int i = 0; i < cnt; i++) for (int j = i + 1; j < cnt; j++)
                {
                    if (nums[i] + nums[j] > target) result++;
                }

            return result;
        }
    }
}
