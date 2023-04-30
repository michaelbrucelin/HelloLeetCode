using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1903
{
    public class Solution1903 : Interface1903
    {
        public string LargestOddNumber(string num)
        {
            int ptr = num.Length - 1;
            while (ptr >= 0 && (num[ptr] & 15 & 1) != 1) ptr--;

            return num.Substring(0, ptr + 1);
        }

        public string LargestOddNumber2(string num)
        {
            int ptr = num.Length;
            while (--ptr >= 0 && (num[ptr] & 15 & 1) != 1) ;

            return num.Substring(0, ptr + 1);
        }
    }
}
