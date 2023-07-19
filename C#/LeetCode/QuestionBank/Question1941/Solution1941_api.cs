using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1941
{
    public class Solution1941_api : Interface1941
    {
        public bool AreOccurrencesEqual(string s)
        {
            return s.GroupBy(c => c).Select(g => g.Count()).Distinct().Count() == 1;
        }
    }
}
