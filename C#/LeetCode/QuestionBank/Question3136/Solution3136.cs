using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3136
{
    public class Solution3136 : Interface3136
    {
        public bool IsValid(string word)
        {
            if (word.Length < 4) return false;

            HashSet<char> vowels = new HashSet<char>() { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
            bool vowel = false, consonant = false;
            foreach (char c in word)
            {
                if (char.IsAsciiLetter(c))
                {
                    if (vowels.Contains(c)) vowel = true; else consonant = true;
                }
                else
                {
                    if (!char.IsAsciiDigit(c)) return false;
                }
            }

            return vowel && consonant;
        }
    }
}
