using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3393
{
    public class Test3393
    {
        public void Test()
        {
            Interface3393 solution = new Solution3393();
            int[][] grid; int k;
            int result, answer;
            int id = 0;

            // 1. 
            grid = [[2, 1, 5], [7, 10, 0], [12, 6, 4]]; k = 11;
            answer = 3;
            result = solution.CountPathsWithXorValue(grid, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            grid = [[1, 3, 3, 3], [0, 3, 3, 2], [3, 0, 1, 1]]; k = 2;
            answer = 5;
            result = solution.CountPathsWithXorValue(grid, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            grid = [[1, 1, 1, 2], [3, 0, 3, 2], [3, 0, 2, 2]]; k = 10;
            answer = 0;
            result = solution.CountPathsWithXorValue(grid, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
