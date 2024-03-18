using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCS.LCS0002
{
    public class Solution0002_api : Interface0002
    {
        public int HalfQuestions(int[] questions)
        {
            int limit = questions.Length >> 1;
            return questions.GroupBy(i => i)
                            .OrderByDescending(g => g.Count())
                            .SelectMany(g => Enumerable.Repeat(g.Key, g.Count()))
                            .Take(limit)
                            .Distinct()
                            .Count();
        }
    }
}
