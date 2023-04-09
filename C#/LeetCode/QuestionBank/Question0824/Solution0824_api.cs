using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0824
{
    public class Solution0824_api : Interface0824
    {
        public string ToGoatLatin(string sentence)
        {
            HashSet<char> vowel = new HashSet<char>() { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
            return string.Join(' ', sentence.Split(' ')
                                            .Select((str, id) => (vowel.Contains(str[0]) ? str : $"{str[1..]}{str[0..1]}")
                                                                 + $"ma{new string('a', id + 1)}"));
        }
    }
}
