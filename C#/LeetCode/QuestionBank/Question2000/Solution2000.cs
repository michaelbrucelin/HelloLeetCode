using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2000
{
    public class Solution2000 : Interface2000
    {
        public string ReversePrefix(string word, char ch)
        {
            char[] buf = word.ToCharArray();
            int ptr = 0, len = word.Length;
            while (ptr < len && buf[ptr] != ch) ptr++;
            if (ptr == len) return word;

            int pl = -1, pr = ptr + 1;
            while (++pl < --pr)
            {
                char t = buf[pl]; buf[pl] = buf[pr]; buf[pr] = t;
            }
            
            return new string(buf);
        }
    }
}
