using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0796
{
    public class Solution0796 : Interface0796
    {
        public bool RotateString(string s, string goal)
        {
            if (s.Length != goal.Length) return false;

            return (s + s).Contains(goal);
        }
    }
}
