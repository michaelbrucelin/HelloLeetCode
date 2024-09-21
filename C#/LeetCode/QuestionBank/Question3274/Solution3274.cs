using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3274
{
    public class Solution3274 : Interface3274
    {
        public bool CheckTwoChessboards(string coordinate1, string coordinate2)
        {
            return ((coordinate1[0] - 'a' + coordinate1[1] - '0') & 1) == ((coordinate2[0] - 'a' + coordinate2[1] - '0') & 1);
        }
    }
}
