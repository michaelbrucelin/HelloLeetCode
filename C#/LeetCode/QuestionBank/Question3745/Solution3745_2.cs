using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3745
{
    public class Solution3745_2 : Interface3745
    {
        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaximizeExpressionOfThree(int[] nums)
        {
            int[] _nums = [int.MaxValue, int.MinValue, int.MinValue];
            foreach (int num in nums)
            {
                if (num < _nums[0])
                {
                    _nums[0] = num;
                }
                if (num > _nums[2])
                {
                    _nums[1] = _nums[2]; _nums[2] = num;
                }
                else if (num > _nums[1])
                {
                    _nums[1] = num;
                }
            }

            return _nums[2] + _nums[1] - _nums[0];
        }
    }
}
