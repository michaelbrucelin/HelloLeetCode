using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0980
{
    public class Test0980
    {
        public void Test()
        {
            Interface0980 solution = new Solution0980_5();
            int[][] grid;
            int result, answer;
            int id = 0;

            // 1. 
            grid = UtilsLeetCode.Str2NumArray_2d<int>("[[1,0,0,0],[0,0,0,0],[0,0,2,-1]]");
            answer = 2;
            result = solution.UniquePathsIII(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            grid = UtilsLeetCode.Str2NumArray_2d<int>("[[1,0,0,0],[0,0,0,0],[0,0,0,2]]");
            answer = 4;
            result = solution.UniquePathsIII(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            grid = UtilsLeetCode.Str2NumArray_2d<int>("[[0,1],[2,0]]");
            answer = 0;
            result = solution.UniquePathsIII(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
