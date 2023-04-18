using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1688
{
    public class Solution1688 : Interface1688
    {
        public int NumberOfMatches(int n)
        {
            int result = 0;
            while (n > 1)
            {
                result += n >> 1;
                if ((n & 1) != 1) n >>= 1; else n = (n >> 1) + 1;
            }

            return result;
        }
    }
}
