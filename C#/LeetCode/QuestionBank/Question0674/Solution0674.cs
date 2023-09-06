using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0674
{
    public class Solution0674 : Interface0674
    {
        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindLengthOfLCIS(int[] nums)
        {
            int result = 1, _r = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                switch (nums[i] - nums[i - 1])
                {
                    case > 0:
                        _r++;
                        break;
                    default:
                        result = Math.Max(result, _r); _r = 1;
                        break;
                }
            }
            result = Math.Max(result, _r);

            return result;
        }
    }
}
