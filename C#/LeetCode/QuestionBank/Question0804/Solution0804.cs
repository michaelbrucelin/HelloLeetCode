using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0804
{
    public class Solution0804 : Interface0804
    {
        private readonly string[] MORSE = new string[] { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.." };

        public int UniqueMorseRepresentations(string[] words)
        {
            if (words.Length == 1) return 1;

            HashSet<string> set = new HashSet<string>(words);
            if (set.Count == 1) return 1;
            HashSet<string> result = new HashSet<string>();
            StringBuilder sb = new StringBuilder();
            foreach (string word in set)
            {
                sb.Clear();
                for (int i = 0; i < word.Length; i++) sb.Append(MORSE[word[i] - 'a']);
                result.Add(sb.ToString());
            }

            return result.Count;
        }
    }
}
