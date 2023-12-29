using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1844
{
    public class Solution1844 : Interface1844
    {
        public string ReplaceDigits(string s)
        {
            char[] chars = s.ToCharArray();
            for (int i = 1; i < s.Length; i += 2)
                chars[i] = (char)(chars[i] - '0' + chars[i - 1]);
            return new string(chars);
        }
    }
}
