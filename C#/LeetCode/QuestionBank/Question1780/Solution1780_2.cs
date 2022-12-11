using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1780
{
    public class Solution1780_2 : Interface1780
    {
        public bool CheckPowersOfThree(int n)
        {
            int remainder;
            while (n > 0)
            {
                var info = Math.DivRem(n, 3);
                if (info.Remainder == 2) return false;
                n = info.Quotient;
            }

            return true;
        }
    }
}
