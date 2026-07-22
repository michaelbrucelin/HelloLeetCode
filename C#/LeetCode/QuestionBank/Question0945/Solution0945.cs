using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0945
{
    public class Solution0945 : Interface0945
    {
        /// <summary>
        /// 排序 + 贪心
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MinIncrementForUnique(int[] nums)
        {
            Array.Sort(nums);
            int result = 0, prev = nums[0] - 1, curr, len = nums.Length;
            for (int i = 0, num; i < len; i++)
            {
                num = nums[i];
                curr = Math.Max(prev + 1, num);
                result += curr - num;
                prev = curr;
            }

            return result;
        }
    }
}
