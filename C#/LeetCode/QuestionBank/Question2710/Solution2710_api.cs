using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2710
{
    public class Solution2710_api : Interface2710
    {
        public string RemoveTrailingZeros(string num)
        {
            return num.TrimEnd('0');
        }

        public string RemoveTrailingZeros2(string num)
        {
            return Regex.Replace(num, @"0*$", "");
        }
    }
}
