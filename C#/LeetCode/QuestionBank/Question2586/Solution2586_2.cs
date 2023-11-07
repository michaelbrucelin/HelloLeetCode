using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2586
{
    public class Solution2586_2 : Interface2586
    {
        private readonly static HashSet<char> vowel = new HashSet<char>() { 'a', 'e', 'i', 'o', 'u' };

        public int VowelStrings(string[] words, int left, int right)
        {
            return words.Skip(left)
                        .Take(right - left + 1)
                        .Count(s => vowel.Contains(s[0]) && vowel.Contains(s[^1]));
        }
    }
}
