using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1876
{
    public class Solution1876 : Interface1876
    {
        public int CountGoodSubstrings(string s)
        {
            if (s.Length < 3) return 0;

            int result = 0;
            for (int i = 0; i < s.Length - 2; i++)
            {
                if (s[i] != s[i + 1] && s[i] != s[i + 2] && s[i + 1] != s[i + 2]) result++;
            }

            return result;
        }

        public int CountGoodSubstrings4(string s)
        {
            if (s.Length < 3) return 0;
            return s.Select((c, id) => (c, id))
                    .Skip(2)
                    .Count(item => item.c != s[item.id - 1] && item.c != s[item.id - 2] && s[item.id - 1] != s[item.id - 2]);
        }
    }
}
