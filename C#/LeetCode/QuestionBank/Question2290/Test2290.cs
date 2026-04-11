using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2290
{
    public class Test2290
    {
        public void Test()
        {
            Interface2290 solution = new Solution2290();
            int[][] grid;
            int result, answer;
            int id = 0;

            // 1. 
            grid = [[0, 1, 1], [1, 1, 0], [1, 1, 0]];
            answer = 2;
            result = solution.MinimumObstacles(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            grid = [[0, 1, 0, 0, 0], [0, 1, 0, 1, 0], [0, 0, 0, 1, 0]];
            answer = 0;
            result = solution.MinimumObstacles(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
