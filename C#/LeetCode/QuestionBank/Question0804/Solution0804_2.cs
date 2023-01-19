using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0804
{
    public class Solution0804_2 : Interface0804
    {
        private readonly string[] MORSE = new string[] { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.." };

        public int UniqueMorseRepresentations(string[] words)
        {
            if (words.Length == 1) return 1;

            HashSet<string> set = new HashSet<string>(words);
            if (set.Count == 1) return 1;
            HashSet<string> result = new HashSet<string>();
            foreach (string word in set)
                result.Add(word.Select(c => MORSE[c - 'a']).Aggregate((s1, s2) => $"{s1}{s2}")); ;

            return result.Count;
        }

        public int UniqueMorseRepresentations2(string[] words)
        {
            if (words.Length == 1) return 1;

            var set = words.ToHashSet();
            if (set.Count == 1) return 1;

            return set.Select(word => word.Select(c => MORSE[c - 'a']).Aggregate((s1, s2) => $"{s1}{s2}")).Distinct().Count();
        }
    }
}
