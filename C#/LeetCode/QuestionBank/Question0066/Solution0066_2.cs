using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0066
{
    public class Solution0066_2 : Interface0066
    {
        public int[] PlusOne(int[] digits)
        {
            List<int> result = new List<int>();
            int extra = 1, add;
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                add = digits[i] + extra;
                if (add >= 10)
                {
                    result.Add(add - 10); extra = 1;
                }
                else
                {
                    result.Add(add); extra = 0;
                }
            }
            if (extra > 0) result.Add(extra);

            // result.Reverse();
            int len = result.Count - 1, half = len >> 1;
            for (int i = 0; i <= half; i++)
            {
                int t = result[i]; result[i] = result[len - i]; result[len - i] = t;
            }
            return result.ToArray();
        }
    }
}
