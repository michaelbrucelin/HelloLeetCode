using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2710
{
    public class Solution2710 : Interface2710
    {
        public string RemoveTrailingZeros(string num)
        {
            int ptr = num.Length - 1;
            while (num[ptr] == '0') ptr--;

            return num.Substring(0, ptr + 1);
        }

        public string RemoveTrailingZeros2(string num)
        {
            return num.TrimEnd('0');
        }

        public string RemoveTrailingZeros3(string num)
        {
            return Regex.Replace(num, @"0*$", "");
        }
    }
}
