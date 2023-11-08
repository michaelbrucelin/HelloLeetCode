using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2609
{
    public class Solution2609 : Interface2609
    {
        public int FindTheLongestBalancedSubstring(string s)
        {
            int result = 0, cnt0, cnt1, ptr = 0, len = s.Length;
            while (ptr < len && s[ptr] == '1') ptr++;
            while (ptr < len && len - ptr + 1 > result)
            {
                cnt0 = cnt1 = 0;
                while (ptr < len && s[ptr] == '0') { cnt0++; ptr++; }
                while (ptr < len && s[ptr] == '1') { cnt1++; ptr++; }
                result = Math.Max(result, Math.Min(cnt0, cnt1));
            }

            return result << 1;
        }
    }
}
