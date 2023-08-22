using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1848
{
    public class Solution1848 : Interface1848
    {
        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <param name="start"></param>
        /// <returns></returns>
        public int GetMinDistance(int[] nums, int target, int start)
        {
            int result = nums.Length + 1, len = nums.Length;
            for (int i = 0; i < len; i++)
            {
                if (nums[i] == target) result = Math.Min(result, Math.Abs(i - start));
            }

            return result;
        }
    }
}
