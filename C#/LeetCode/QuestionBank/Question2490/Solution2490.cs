using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2490
{
    public class Solution2490 : Interface2490
    {
        public bool IsCircularSentence(string sentence)
        {
            if (sentence[0] != sentence[^1]) return false;
            for (int i = 0; i < sentence.Length; i++) if (sentence[i] == ' ')
                {
                    if (sentence[i - 1] != sentence[i + 1]) return false;
                }

            return true;
        }
    }
}
