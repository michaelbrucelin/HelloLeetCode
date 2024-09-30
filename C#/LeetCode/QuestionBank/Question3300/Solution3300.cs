using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3300
{
    public class Solution3300 : Interface3300
    {
        public int MinElement(int[] nums)
        {
            int result = int.MaxValue;
            foreach (int num in nums)
            {
                result = Math.Min(result, DigitSum(num));
            }

            return result;

            int DigitSum(int x)
            {
                int result = 0;
                while (x > 0)
                {
                    result += x % 10; x /= 10;
                }

                return result;
            }
        }
    }
}
