using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0657
{
    public class Solution0657_api : Interface0657
    {
        public bool JudgeCircle(string moves)
        {
            return moves.Count(c => c == 'U') == moves.Count(c => c == 'D')
                && moves.Count(c => c == 'L') == moves.Count(c => c == 'R');
        }
    }
}
