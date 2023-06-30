using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2490
{
    public class Solution2490_api : Interface2490
    {
        public bool IsCircularSentence(string sentence)
        {
            if (sentence[0] != sentence[^1]) return false;
            return sentence.Select((c, id) => (c, id)).Where(t => t.c == ' ').All(t => sentence[t.id - 1] == sentence[t.id + 1]);
        }

        public bool IsCircularSentence2(string sentence)
        {
            if (sentence[0] != sentence[^1]) return false;
            string[] strs = sentence.Split(' ');
            return strs.Skip(1).Zip(strs, (s2, s1) => (s1, s2)).All(t => t.s1[^1] == t.s2[0]);
        }
    }
}
