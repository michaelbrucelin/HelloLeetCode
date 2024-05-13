using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0006
{
    public class Solution0006 : Interface0006
    {
        /// <summary>
        /// 双指针
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] TwoSum(int[] numbers, int target)
        {
            int left = 0, right = numbers.Length - 1;
            while (left < right) switch (numbers[left] + numbers[right] - target)
                {
                    case > 0: right--; break;
                    case < 0: left++; break;
                    default: return [left, right];
                }

            throw new Exception("logic error.");
        }
    }
}
