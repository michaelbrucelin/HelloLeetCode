using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview1602
{
    public class Solution1602
    {
    }

    /// <summary>
    /// 字典
    /// </summary>
    public class WordsFrequency : Interface1602
    {
        public WordsFrequency(string[] book)
        {
            map = new Dictionary<string, int>();
            // foreach (string word in book) if (map.ContainsKey(word)) map[word]++; else map.Add(word, 1);
            foreach (string word in book) if (map.TryGetValue(word, out int value)) map[word] = ++value; else map.Add(word, 1);
        }

        Dictionary<string, int> map;

        public int Get(string word)
        {
            // return map.ContainsKey(word) ? map[word] : 0;
            return map.TryGetValue(word, out int value) ? value : 0;
        }
    }
}
