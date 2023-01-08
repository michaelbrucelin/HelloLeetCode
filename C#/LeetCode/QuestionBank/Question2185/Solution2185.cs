using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2185
{
    public class Solution2185 : Interface2185
    {
        public int PrefixCount(string[] words, string pref)
        {
            int result = 0;
            for (int i = 0; i < words.Length; i++) if (words[i].StartsWith(pref)) result++;

            return result;
        }

        public int PrefixCount2(string[] words, string pref)
        {
            return words.Where(s => s.StartsWith(pref)).Count();
        }
    }
}
