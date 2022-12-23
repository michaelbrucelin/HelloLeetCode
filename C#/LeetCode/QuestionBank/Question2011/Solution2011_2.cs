using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2011
{
    public class Solution2011_2 : Interface2011
    {
        public int FinalValueAfterOperations(string[] operations)
        {
            int result = 0;
            for (int i = 0; i < operations.Length; i++)
                result += (44 - operations[i][1]);  // + 与 - 对应的ASCII值分别是43与45

            return result;
        }
    }
}
