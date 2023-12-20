using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2828
{
    public class Solution2828 : Interface2828
    {
        public bool IsAcronym(IList<string> words, string s)
        {
            if (words.Count != s.Length) return false;

            for (int i = 0; i < words.Count; i++) if (words[i][0] != s[i]) return false;

            return true;
        }
    }
}
