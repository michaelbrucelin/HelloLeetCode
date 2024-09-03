using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2708
{
    public class Solution2708 : Interface2708
    {
        /// <summary>
        /// 分类讨论 + 贪心
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public long MaxStrength(int[] nums)
        {
            if (nums.Length == 1) return nums[0];

            int poscnt = 0, zerocnt = 0, negcnt = 0, negmax = int.MinValue;
            foreach (int num in nums) switch (num)
                {
                    case > 0:
                        poscnt++;
                        break;
                    case < 0:
                        negcnt++; negmax = Math.Max(negmax, num);
                        break;
                    default:
                        zerocnt++;
                        break;
                }
            if (poscnt == 0 && negcnt < 2) return 0;  // return zerocnt > 0 ? 0 : negmax;

            long result = 1;
            foreach (int num in nums) if (num != 0) result *= num;
            if ((negcnt & 1) != 0) result /= negmax;

            return result;
        }
    }
}
