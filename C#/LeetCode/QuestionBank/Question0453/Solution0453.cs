using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0453
{
    public class Solution0453 : Interface0453
    {
        /// <summary>
        /// 数学
        /// 反过来想就很简单，相当于每次只能给一个元素减1
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MinMoves(int[] nums)
        {
            int sum = nums[0], min = nums[0], len = nums.Length;
            for (int i = 1; i < nums.Length; i++) { sum += nums[i]; min = Math.Min(min, nums[i]); }

            return sum - min * len;
        }
    }
}
