using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2423
{
    public class Solution2423 : Interface2423
    {
        public bool EqualFrequency(string word)
        {
            Dictionary<char, int> freq = new Dictionary<char, int>();
            for (int i = 0; i < word.Length; i++)
            {
                if (freq.ContainsKey(word[i])) freq[word[i]]++; else freq.Add(word[i], 1);
            }
            if (freq.Count == 1) return true;

            Dictionary<int, int> map = new Dictionary<int, int>();
            foreach (int i in freq.Values)
            {
                if (map.ContainsKey(i)) map[i]++; else map.Add(i, 1);
            }
            if (map.Count > 2) return false;
            if (map.Count == 1) return map.First().Key == 1;

            return (map.First().Value == 1 && ((map.First().Key == 1) || map.First().Key - map.Last().Key == 1)) ||
                   (map.Last().Value == 1 && ((map.Last().Key == 1) || map.Last().Key - map.First().Key == 1)) ? true : false;
        }
    }
}
