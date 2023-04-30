using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0824
{
    public class Solution0824_2 : Interface0824
    {
        public string ToGoatLatin(string sentence)
        {
            StringBuilder result = new StringBuilder();
            HashSet<char> vowel = new HashSet<char>() { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
            string[] words = sentence.Split(' '); string word;
            for (int i = 0; i < words.Length; i++)
            {
                word = words[i];
                if (vowel.Contains(word[0]))
                    result.Append(word);
                else
                    result.Append($"{word[1..]}{word[0..1]}");
                result.Append($"ma{new string('a', i + 1)} ");
            }
            result.Remove(result.Length - 1, 1);

            return result.ToString();
        }
    }
}
