using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2506
{
    public class Solution2506_api : Interface2506
    {
        public int SimilarPairs(string[] words)
        {
            return words.Select(s => s.Select(c => 1 << (c - 'a')).Aggregate((i1, i2) => i1 | i2))
                        .GroupBy(i => i)
                        .Select(g => g.Count())
                        .Sum(i => i * (i - 1) >> 1);
        }
    }
}
