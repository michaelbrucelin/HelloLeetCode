using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0066
{
    public class Solution0066_3 : Interface0066
    {
        public int[] PlusOne(int[] digits)
        {
            int len = digits.Length, extra = 1;
            for (int i = len - 1; i >= 0; i--)
            {
                int add = digits[i] + extra;
                if (add >= 10)
                {
                    digits[i] = add - 10; extra = 1;
                }
                else
                {
                    digits[i] = add; extra = 0;
                    break;
                }
            }
            if (extra == 0) return digits;

            int[] result = new int[len + 1];
            result[0] = extra;
            for (int i = 0; i < len; i++) result[i + 1] = digits[i];
            return result;
        }
    }
}
