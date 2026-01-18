using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1895
{
    public class Test1895
    {
        public void Test()
        {
            Interface1895 solution = new Solution1895_2();
            int[][] grid;
            int result, answer;
            int id = 0;

            // 1. 
            grid = [[7, 1, 4, 5, 6], [2, 5, 1, 6, 4], [1, 5, 4, 3, 2], [1, 2, 7, 3, 4]];
            answer = 3;
            result = solution.LargestMagicSquare(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            grid = [[5, 1, 3, 1], [9, 3, 3, 1], [1, 3, 3, 8]];
            answer = 2;
            result = solution.LargestMagicSquare(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
