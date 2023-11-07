using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2586
{
    public class Solution2586 : Interface2586
    {
        private readonly static HashSet<char> vowel = new HashSet<char>() { 'a', 'e', 'i', 'o', 'u' };

        public int VowelStrings(string[] words, int left, int right)
        {
            int result = 0;
            for (int i = left; i <= right; i++)
                if (vowel.Contains(words[i][0]) && vowel.Contains(words[i][^1])) result++;

            return result;
        }
    }
}
