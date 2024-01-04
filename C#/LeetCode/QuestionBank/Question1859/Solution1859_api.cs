using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1859
{
    public class Solution1859_api : Interface1859
    {
        public string SortSentence(string s)
        {
            return string.Join(' ', s.Split(' ').OrderBy(s => s[^1] - '1').Select(s => s[..^1]));
        }
    }
}
