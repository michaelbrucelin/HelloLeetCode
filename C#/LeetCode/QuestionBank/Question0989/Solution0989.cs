using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0989
{
    public class Solution0989 : Interface0989
    {
        public IList<int> AddToArrayForm(int[] num, int k)
        {
            List<int> result = new List<int>();
            int carry = 0, ptr = num.Length - 1;
            while (ptr >= 0 && k > 0)
            {
                var info = Math.DivRem(k, 10);
                result.Add((num[ptr] + info.Remainder + carry) % 10); carry = (num[ptr] + info.Remainder + carry) / 10;
                ptr--; k = info.Quotient;
            }
            while (ptr >= 0)
            {
                result.Add((num[ptr] + carry) % 10); carry = (num[ptr] + carry) / 10;
                ptr--;
            }
            while (k > 0)
            {
                var info = Math.DivRem(k, 10);
                result.Add((info.Remainder + carry) % 10); carry = (info.Remainder + carry) / 10;
                k = info.Quotient;
            }
            if (carry > 0) result.Add(carry);

            result.Reverse();
            return result;
        }
    }
}
