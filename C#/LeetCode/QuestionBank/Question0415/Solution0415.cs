using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0415
{
    public class Solution0415 : Interface0415
    {
        public string AddStrings(string num1, string num2)
        {
            int ptr1 = num1.Length - 1, ptr2 = num2.Length - 1;
            char[] result = new char[Math.Max(ptr1, ptr2) + 2];

            int ptr = result.Length - 1, i1, i2, carry = 0;
            while (ptr1 >= 0 && ptr2 >= 0)
            {
                i1 = num1[ptr1] & 15; i2 = num2[ptr2] & 15;
                result[ptr--] = (char)(((i1 + i2 + carry) % 10) | 48);
                carry = (i1 + i2 + carry) / 10;
                ptr1--; ptr2--;
            }
            if (ptr2 >= 0) { num1 = num2; ptr1 = ptr2; }
            while (ptr1 >= 0)
            {
                i1 = num1[ptr1] & 15;
                result[ptr--] = (char)(((i1 + carry) % 10) | 48);
                carry = (i1 + carry) / 10;
                ptr1--;
            }
            if (carry > 0) result[ptr] = (char)(carry | 48);

            return result[0] != '\0' ? new string(result) : new string(result, 1, result.Length - 1);
        }
    }
}
