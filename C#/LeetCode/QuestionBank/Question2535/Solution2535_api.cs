using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2535
{
    public class Solution2535_api : Interface2535
    {
        public int DifferenceOfSum(int[] nums)
        {
            return Math.Abs(nums.Sum() - nums.Sum(i => i.ToString().Sum(c => c & 15)));
        }

        /// <summary>
        /// 数字一定大于数位和
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int DifferenceOfSum2(int[] nums)
        {
            return nums.Sum() - nums.Sum(i => i.ToString().Sum(c => c & 15));
        }
    }
}
