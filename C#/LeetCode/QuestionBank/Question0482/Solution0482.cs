using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0482
{
    public class Solution0482 : Interface0482
    {
        public string LicenseKeyFormatting(string s, int k)
        {
            StringBuilder result = new StringBuilder();
            for (int i = s.Length - 1, cnt = 0; i >= 0; i--)
            {
                char c = s[i];
                if (c == '-') continue;
                if (char.IsLower(c)) c = (char)(c & (~32));
                result.Insert(0, c);
                if (++cnt == k)
                {
                    result.Insert(0, '-'); cnt = 0;
                }
            }
            if (result.Length == 0) return "";

            return result[0] == '-' ? result.ToString(1, result.Length - 1) : result.ToString();
        }
    }
}
