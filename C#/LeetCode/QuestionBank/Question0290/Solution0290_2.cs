using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0290
{
    public class Solution0290_2 : Interface0290
    {
        public bool WordPattern(string pattern, string s)
        {
            string[] strs = s.Split(' ');
            return Enumerable.SequenceEqual(pattern.Select(c => pattern.IndexOf(c)),
                                            strs.Select(s => strs.TakeWhile(ss => ss != s).Count()));
        }

        public bool WordPattern2(string pattern, string s)
        {
            string[] strs = s.Split(' ');
            return Enumerable.SequenceEqual(pattern.Select(c => pattern.IndexOf(c)),
                                            strs.Select(s => strs.Select((ss, id) => (ss, id)).Where(item => item.ss == s).First().id));
        }
    }
}
