using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3105
{
    public class Solution3105 : Interface3105
    {
        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int LongestMonotonicSubarray(int[] nums)
        {
            int result = 1, asc = 1, desc = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                switch (nums[i] - nums[i - 1])
                {
                    case > 0:
                        result = Math.Max(result, desc);
                        asc++; desc = 1;
                        break;
                    case < 0:
                        result = Math.Max(result, asc);
                        desc++; asc = 1;
                        break;
                    default:    // == 0
                        result = Math.Max(result, desc);
                        result = Math.Max(result, asc);
                        desc = 1; asc = 1;
                        break;
                }
            }
            result = Math.Max(result, desc);
            result = Math.Max(result, asc);

            return result;
        }
    }
}
