using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3110
{
    public class Solution3110_api : Interface3110
    {
        public int ScoreOfString(string s)
        {
            return Enumerable.Range(1, s.Length - 1).Select(i => Math.Abs(s[i] - s[i - 1])).Sum();
        }
    }
}
