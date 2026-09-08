using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3978
{
    public class Solution3978 : Interface3978
    {
        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool IsMiddleElementUnique(int[] nums)
        {
            int mid = nums[nums.Length >> 1];
            for (int i = 0, j = nums.Length - 1; i < j; i++, j--)
            {
                if (nums[i] == mid || nums[j] == mid) return false;
            }

            return true;
        }
    }
}
