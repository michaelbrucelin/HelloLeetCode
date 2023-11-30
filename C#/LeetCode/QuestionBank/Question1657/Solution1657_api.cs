using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1657
{
    public class Solution1657_api : Interface1657
    {
        public bool CloseStrings(string word1, string word2)
        {
            if (word1.Length != word2.Length) return false;

            int mask1 = word1.Select(c => 1 << (c - 'a')).Aggregate((i, j) => i | j);
            int mask2 = word2.Select(c => 1 << (c - 'a')).Aggregate((i, j) => i | j);
            if (mask1 != mask2) return false;

            int[] freq1 = word1.Select(c => c - 'a').GroupBy(i => i).Select(g => g.Count()).OrderBy(i => i).ToArray();
            int[] freq2 = word2.Select(c => c - 'a').GroupBy(i => i).Select(g => g.Count()).OrderBy(i => i).ToArray();
            return Enumerable.SequenceEqual(freq1, freq2);
        }
    }
}
