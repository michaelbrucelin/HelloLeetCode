using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1576
{
    public class Solution1576 : Interface1576
    {
        public string ModifyString(string s)
        {
            if (s.Length == 1) return s == "?" ? "a" : s;

            char[] chars = s.ToCharArray();
            int len = chars.Length;
            if (chars[0] == '?') chars[0] = chars[1] != 'a' ? 'a' : 'b';
            if (chars[len - 1] == '?') chars[len - 1] = chars[len - 2] != 'a' ? 'a' : 'b';
            char c;
            for (int i = 1; i < len - 1; i++)
            {
                if (chars[i] != '?') continue;
                c = 'a';
                if (chars[i - 1] == 'a' || chars[i + 1] == 'a')
                {
                    c = 'b';
                    if (chars[i - 1] == 'b' || chars[i + 1] == 'b') c = 'c';
                }
                chars[i] = c;
            }

            return new string(chars);
        }
    }
}
