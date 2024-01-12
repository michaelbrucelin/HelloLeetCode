using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2255
{
    public class Solution2255 : Interface2255
    {
        public int CountPrefixes(string[] words, string s)
        {
            int result = 0;
            foreach (string word in words)
                if (s.StartsWith(word)) result++;

            return result;
        }
    }
}
