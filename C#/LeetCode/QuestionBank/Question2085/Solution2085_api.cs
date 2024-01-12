using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2085
{
    public class Solution2085_api : Interface2085
    {
        public int CountWords(string[] words1, string[] words2)
        {
            var s1 = words1.GroupBy(s => s).Where(g => g.Count() == 1).Select(g => g.Key).ToHashSet();
            var s2 = words2.GroupBy(s => s).Where(g => g.Count() == 1).Select(g => g.Key).ToHashSet();

            return s1.Intersect(s2).Count();
        }
    }
}
