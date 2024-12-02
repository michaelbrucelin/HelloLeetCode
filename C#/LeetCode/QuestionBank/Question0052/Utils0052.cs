using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0052
{
    public class Utils0052
    {
        public void Dial()
        {
            Interface0052 solution = new Solution0052();
            int[] dial = new int[10];
            for (int i = 1; i < 10; i++) dial[i] = solution.TotalNQueens(i);
            Utils.Dump(dial);
        }
    }
}
