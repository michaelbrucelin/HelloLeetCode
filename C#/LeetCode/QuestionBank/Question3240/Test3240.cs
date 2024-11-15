using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3240
{
    public class Test3240
    {
        public void Test()
        {
            Interface3240 solution = new Solution3240_err();
            int[][] grid;
            int result, answer;
            int id = 0;

            // 1. 
            grid = [[1, 0, 0], [0, 1, 0], [0, 0, 1]];
            answer = 3;
            result = solution.MinFlips(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            grid = [[0, 1], [0, 1], [0, 0]];
            answer = 2;
            result = solution.MinFlips(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            grid = [[1], [1]];
            answer = 2;
            result = solution.MinFlips(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            grid = [[0, 0, 1], [1, 1, 0], [1, 1, 1], [0, 1, 1]];
            answer = 4;
            result = solution.MinFlips(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
