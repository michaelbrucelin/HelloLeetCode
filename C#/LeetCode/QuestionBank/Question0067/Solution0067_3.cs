using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0067
{
    public class Solution0067_3 : Interface0067
    {
        public string AddBinary(string a, string b)
        {
            int p1 = a.Length - 1, p2 = b.Length - 1;
            StringBuilder buffer = new StringBuilder();
            int i1, i2, add, carry = 0;
            while (p1 >= 0 || p2 >= 0)
            {
                i1 = p1 >= 0 ? a[p1] & 15 : 0;
                i2 = p2 >= 0 ? b[p2] & 15 : 0;
                add = i1 + i2 + carry;
                carry = (add >> 1) & 1;
                buffer.Insert(0, add & 1);
                p1--; p2--;
            }
            if (carry != 0) buffer.Insert(0, carry);

            return buffer.ToString();
        }
    }
}
