using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1002
{
    public class Solution1002 : Interface1002
    {
        public IList<string> CommonChars(string[] words)
        {
            int[] freq = new int[26], _freq;
            for (int i = 0; i < words[0].Length; i++) freq[words[0][i] - 'a']++;
            for (int i = 1; i < words.Length; i++)
            {
                _freq = new int[26];
                for (int j = 0; j < words[i].Length; j++)
                {
                    int id = words[i][j] - 'a';
                    if (freq[id] > 0) { _freq[id]++; freq[id]--; }
                }
                freq = _freq;
            }

            List<string> result = new List<string>();
            for (int i = 0; i < 26; i++) for (int j = 0; j < freq[i]; j++) result.Add($"{(char)('a' + i)}");
            return result;
        }

        public IList<string> CommonChars2(string[] words)
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
