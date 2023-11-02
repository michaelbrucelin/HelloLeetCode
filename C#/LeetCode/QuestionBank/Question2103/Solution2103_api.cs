using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2103
{
    public class Solution2103_api : Interface2103
    {
        public int CountPoints(string rings)
        {
            return Enumerable.Range(0, rings.Length >> 1)
                             .Select(i => (i << 1) + 1)
                             .Select(i => (rings[i], rings[i - 1]))
                             .GroupBy(t => t.Item1)
                             .Count(g => g.Distinct().Count() == 3);
        }
    }
}
