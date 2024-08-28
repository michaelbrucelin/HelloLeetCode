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
            HashSet<char> vowels = new HashSet<char>() { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
            StringBuilder result = new StringBuilder();
            int len = sentence.Length, id = 1, p1 = 0, p2;
            while (p1 < len)
            {
                if (p1 != 0) result.Append(" ");
                p2 = p1;
                while (p2 < len && sentence[p2] != ' ') p2++;
                if (vowels.Contains(sentence[p1]))
                {
                    result.Append(sentence[p1..p2]);
                }
                else
                {
                    result.Append(sentence[(p1 + 1)..p2]);
                    result.Append(sentence[p1]);
                }
                result.Append("ma");
                for (int i = 0; i < id; i++) result.Append('a');
                p1 = p2 + 1;
                id++;
            }

            return result.ToString();
        }

        public string ToGoatLatin2(string sentence)
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
