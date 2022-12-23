using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2011
{
    public class Solution2011 : Interface2011
    {
        public int FinalValueAfterOperations(string[] operations)
        {
            int result = 0;
            for (int i = 0; i < operations.Length; i++)
            {
                if (operations[i] == "X++" || operations[i] == "++X") result++; else result--;
            }

            return result;
        }
    }
}
