using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2132
{
    public class Test2132
    {
        public void Test()
        {
            Interface2132 solution = new Solution2132_2();
            int[][] grid; int stampHeight, stampWidth;
            bool result, answer;
            int id = 0;

            // 1. 
            grid = Utils.Str2NumArray_2d<int>("[[1,0,0,0],[1,0,0,0],[1,0,0,0],[1,0,0,0],[1,0,0,0]]");
            stampHeight = 4; stampWidth = 3;
            answer = true;
            result = solution.PossibleToStamp(grid, stampHeight, stampWidth);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            grid = Utils.Str2NumArray_2d<int>("[[1,0,0,0],[0,1,0,0],[0,0,1,0],[0,0,0,1]]");
            stampHeight = 2; stampWidth = 2;
            answer = false;
            result = solution.PossibleToStamp(grid, stampHeight, stampWidth);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
