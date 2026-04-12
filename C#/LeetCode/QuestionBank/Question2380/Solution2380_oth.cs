using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2380
{
    public class Solution2380_oth : Interface2380
    {
        public int SecondsToRemoveOccurrences(string s)
        {
            int p = 0, cnt = 0, len = s.Length;
            while (p < len && s[p] == '1') p++;
            if (p == len) return 0;
            while (p < len && s[p] == '0') { cnt++; p++; }
            if (p == len) return 0;

            int result = 0;
            while (p < len) if (s[p - 1] == '1')  // p > 0
                {

                }

            return result;
        }
    }
}
