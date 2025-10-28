using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3683
{
    public class Solution3683_api : Interface3683
    {
        public int EarliestTime(int[][] tasks)
        {
            return tasks.Min(x => x[0] + x[1]);
        }
    }
}
