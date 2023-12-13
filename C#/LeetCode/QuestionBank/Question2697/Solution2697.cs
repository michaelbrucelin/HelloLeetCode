using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2697
{
    public class Solution2697 : Interface2697
    {
        public string MakeSmallestPalindrome(string s)
        {
            char[] chars = s.ToCharArray();
            for (int i = 0, j = chars.Length - 1; i < j; i++, j--)
            {
                if (chars[i] < chars[j]) chars[j] = chars[i]; else chars[i] = chars[j];
            }

            return new string(chars);
        }
    }
}
