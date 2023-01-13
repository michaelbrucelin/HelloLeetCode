using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0191
{
    public class Solution0191_3 : Interface0191
    {
        public int HammingWeight(uint n)
        {
            int result = 0;
            while (n > 0)
            {
                result++;
                n &= n - 1;
            }

            return result;
        }
    }
}
