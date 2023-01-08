using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0066
{
    public class Solution0066 : Interface0066
    {
        public int[] PlusOne(int[] digits)
        {
            int[] result;
            int len = digits.Length;
            if (digits.All(i => i == 9))
            {
                result = new int[len + 1]; result[0] = 1;
            }
            else
            {
                result = digits;
                int extra = 1;
                for (int i = len - 1; i >= 0; i--)
                {
                    int add = digits[i] + extra;
                    if (add < 10)
                    {
                        digits[i] = add;
                        break;
                    }
                    else
                    {
                        digits[i] = add - 10;
                        extra = 1;
                    }
                }
            }

            return result;
        }
    }
}
