using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1160
{
    public class Solution1160_api : Interface1160
    {
        public int CountCharacters(string[] words, string chars)
        {
            var freq = chars.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());
            return words.Select(str => (str.Length, str.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count())))
                        .Where(t => t.Item2.All(kv => freq.ContainsKey(kv.Key) && kv.Value <= freq[kv.Key]))
                        .Sum(t => t.Item1);
        }
    }
}
