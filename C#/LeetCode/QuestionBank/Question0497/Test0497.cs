using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0497
{
    public class Test0497
    {
        public void Test()
        {
            Interface0497 solution;
            int[][] rects;

            // 1. 
            rects = [[-2, -2, 1, 1], [2, 2, 4, 6]];
            solution = new Solution(rects);
            Utils.Dump(solution.Pick());
        }
    }
}
