using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2255
{
    public class Solution2255_api : Interface2255
    {
        public int CountPrefixes(string[] words, string s)
        {
            return words.Count(word => s.StartsWith(word));
        }
    }
}
