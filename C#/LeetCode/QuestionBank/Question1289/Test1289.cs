using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1289
{
    public class Test1289
    {
        public void Test()
        {
            Interface1289 solution = new Solution1289();
            int[][] grid;
            int result, answer;
            int id = 0;

            // 1. 
            grid = UtilsLeetCode.Str2NumArray_2d<int>("[[1,2,3],[4,5,6],[7,8,9]]");
            answer = 13;
            result = solution.MinFallingPathSum(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            grid = UtilsLeetCode.Str2NumArray_2d<int>("[[7]]");
            answer = 7;
            result = solution.MinFallingPathSum(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            grid = UtilsLeetCode.Str2NumArray_2d<int>("[[-73,61,43,-48,-36],[3,30,27,57,10],[96,-76,84,59,-15],[5,-49,76,31,-7],[97,91,61,-46,67]]");
            answer = -192;
            result = solution.MinFallingPathSum(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
