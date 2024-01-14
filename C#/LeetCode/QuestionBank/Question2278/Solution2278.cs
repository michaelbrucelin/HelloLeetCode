using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2278
{
    public class Solution2278 : Interface2278
    {
        public int PercentageLetter(string s, char letter)
        {
            int cnt = 0, len = s.Length;
            for (int i = 0; i < len; i++)
                if (s[i] == letter) cnt++;

            return 100 * cnt / len;
        }
    }
}
