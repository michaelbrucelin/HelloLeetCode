using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3019
{
    public class Solution3019 : Interface3019
    {
        public int CountKeyChanges(string s)
        {
            int result = 0;
            for (int i = 1; i < s.Length; i++)
                if (s[i] != s[i - 1] && (s[i] ^ s[i - 1]) != 32) result++;

            return result;
        }
    }
}
