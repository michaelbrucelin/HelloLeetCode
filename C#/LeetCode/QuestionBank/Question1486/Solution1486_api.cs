using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1486
{
    public class Solution1486_api : Interface1486
    {
        public int XorOperation(int n, int start)
        {
            return Enumerable.Range(0, n).Select(i => start + (i << 1)).Aggregate((i, j) => i ^ j);
        }
    }
}
