using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0049
{
    public class Solution0049_api : Interface0049
    {
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            return strs.Select(s => (string.Concat(s.OrderBy(c => c)), s))
                       .GroupBy(t => t.Item1)
                       .Select(g => (IList<string>)g.Select(t => t.Item2).ToList())
                       .ToList();
        }
    }
}
