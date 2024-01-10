using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2089
{
    public class Solution2089 : Interface2089
    {
        /// <summary>
        /// 暴力枚举
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public IList<int> TargetIndices(int[] nums, int target)
        {
            List<int> result = new List<int>();
            Array.Sort(nums);
            for (int i = 0; i < nums.Length && nums[i] <= target; i++)
            {
                if (nums[i] == target) result.Add(i);
            }

            return result;
        }
    }
}
