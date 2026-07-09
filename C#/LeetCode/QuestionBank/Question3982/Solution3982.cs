using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3982
{
    public class Solution3982 : Interface3982
    {
        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaxDigitRange(int[] nums)
        {
            int result = -1, diff = -1, len = nums.Length;
            for (int i = 0, num, _diff; i < len; i++)
            {
                num = nums[i];
                _diff = maxdiff(num);
                switch (_diff - diff)
                {
                    case 0: result += num; break;
                    case > 0: result = num; diff = _diff; break;
                    default: break;
                }
            }

            return result;

            static int maxdiff(int x)
            {
                int max = -1, min = 10, d;
                while (x > 0)
                {
                    d = x % 10;
                    max = Math.Max(max, d);
                    min = Math.Min(min, d);
                    x /= 10;
                }

                return max - min;
            }
        }
    }
}
