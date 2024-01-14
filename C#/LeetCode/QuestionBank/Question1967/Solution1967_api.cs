using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1967
{
    public class Solution1967_api : Interface1967
    {
        public int NumOfStrings(string[] patterns, string word)
        {
            return patterns.Count(pattern => word.Contains(pattern));
        }
    }
}
