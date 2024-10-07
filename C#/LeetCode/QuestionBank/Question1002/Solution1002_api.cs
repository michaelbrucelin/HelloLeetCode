using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1002
{
    public class Solution1002_api : Interface1002
    {
        public IList<string> CommonChars(string[] words)
        {
            if (words.Length == 1) return words[0].Select(c => $"{c}").ToArray();

            var freqs = words.Select(s => s.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count())).ToArray();
            return freqs.Select(dic => (IEnumerable<char>)dic.Keys)
                        .Aggregate((arr1, arr2) => arr1.Intersect(arr2))
                        .Select(c => new string(c, freqs.Select(dic => dic[c]).Min()))
                        .DefaultIfEmpty(string.Empty)
                        .Aggregate((s1, s2) => $"{s1}{s2}")
                        .Select(c => $"{c}")
                        .ToArray();
        }
    }
}
