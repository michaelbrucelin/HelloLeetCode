using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2553
{
    public class Solution2553 : Interface2553
    {
        public int[] SeparateDigits(int[] nums)
        {
            List<int> result = new List<int>();
            for (int i = nums.Length - 1, num; i >= 0; i--)
            {
                num = nums[i];
                while (num > 0)
                {
                    var info = Math.DivRem(num, 10);
                    result.Add(info.Remainder);
                    num = info.Quotient;
                }
            }
            result.Reverse();

            return result.ToArray();
        }
    }
}
