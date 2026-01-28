using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3760
{
    public class Solution3760_api : Interface3760
    {
        public int MaxDistinct(string s)
        {
            return s.ToHashSet().Count();
        }
    }
}
