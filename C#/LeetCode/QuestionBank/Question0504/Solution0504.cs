using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0504
{
    public class Solution0504 : Interface0504
    {
        public string ConvertToBase7(int num)
        {
            if (num == 0) return "0";

            bool flag = false;
            if (num < 0) { num = -num; flag = true; }
            StringBuilder result = new StringBuilder();
            (int Quotient, int Remainder) t;
            while (num > 0)
            {
                t = Math.DivRem(num, 7);
                result.Insert(0, t.Remainder);
                num = t.Quotient;
            }
            if (flag) result.Insert(0, '-');

            return result.ToString();
        }
    }
}
