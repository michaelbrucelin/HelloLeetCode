using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1594
{
    public class Test1594
    {
        public void Test()
        {
            Interface1594 solution = new Solution1594();
            int[][] grid;
            int result, answer;
            int id = 0;

            // 1. 
            grid = [[-1, -2, -3], [-2, -3, -3], [-3, -3, -2]];
            answer = -1;
            result = solution.MaxProductPath(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            grid = [[1, -2, 1], [1, -2, 1], [3, -4, 1]];
            answer = 8;
            result = solution.MaxProductPath(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            grid = [[1, 3], [0, -4]];
            answer = 0;
            result = solution.MaxProductPath(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            grid = [[2, 1, 3, 0, -3, 3, -4, 4, 0, -4], [-4, -3, 2, 2, 3, -3, 1, -1, 1, -2], [-2, 0, -4, 2, 4, -3, -4, -1, 3, 4], [-1, 0, 1, 0, -3, 3, -2, -3, 1, 0], [0, -1, -2, 0, -3, -4, 0, 3, -2, -2],
                    [-4, -2, 0, -1, 0, -3, 0, 4, 0, -3], [-3, -4, 2, 1, 0, -4, 2, -4, -1, -3], [3, -2, 0, -4, 1, 0, 1, -3, -1, -1], [3, -4, 0, 2, 0, -2, 2, -4, -2, 4], [0, 4, 0, -3, -4, 3, 3, -1, -2, -2]];
            answer = 19215865;
            result = solution.MaxProductPath(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
