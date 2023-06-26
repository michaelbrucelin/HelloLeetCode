using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1897
{
    public class Solution1897_2 : Interface1897
    {
        public bool MakeEqual(string[] words)
        {
            int len = words.Length;
            return words.SelectMany(s => s).GroupBy(c => c).Select(g => g.Count()).All(i => i % len == 0);
        }
    }
}
