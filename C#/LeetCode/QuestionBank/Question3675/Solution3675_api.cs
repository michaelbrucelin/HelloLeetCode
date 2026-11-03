using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3675
{
    public class Solution3675_api : Interface3675
    {
        public int MinOperations(string s)
        {
            return s.Max(c => (26 - c + 'a') % 26);
        }
    }
}
