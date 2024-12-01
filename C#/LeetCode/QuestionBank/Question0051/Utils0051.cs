using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0051
{
    public class Utils0051
    {
        public void Dial()
        {
            Interface0051 solution = new Solution0051();
            for (int i = 1; i < 10; i++)
            {
                Utils.Dump(solution.SolveNQueens(i));
            }
        }
    }
}
