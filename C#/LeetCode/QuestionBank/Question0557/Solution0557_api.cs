using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0557
{
    public class Solution0557_api : Interface0557
    {
        public string ReverseWords(string s)
        {
            return string.Join(' ', s.Split(' ').Select(s => new string(s.Reverse().ToArray())));
        }
    }
}
