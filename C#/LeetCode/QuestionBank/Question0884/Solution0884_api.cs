using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0884
{
    public class Solution0884_api : Interface0884
    {
        public string[] UncommonFromSentences(string s1, string s2)
        {
            return s1.Split(' ').Concat(s2.Split(' '))
                     .GroupBy(str => str)
                     .Where(g => g.Count() == 1)
                     .Select(g => g.Key)
                     .ToArray();
        }
    }
}
