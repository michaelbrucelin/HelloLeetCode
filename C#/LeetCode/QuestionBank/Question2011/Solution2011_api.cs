using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2011
{
    public class Solution2011_api : Interface2011
    {
        public int FinalValueAfterOperations(string[] operations)
        {
            return operations.Sum(x => 44 - x[1]);
        }
    }
}
