using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2683
{
    public class Solution2683_api : Interface2683
    {
        public bool DoesValidArrayExist(int[] derived)
        {
            return derived.Aggregate(0, (x, y) => x ^ y) == 0;
        }
    }
}
