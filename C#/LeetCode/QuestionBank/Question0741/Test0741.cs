using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0741
{
    public class Test0741
    {
        public void Test()
        {
            Interface0741 solution = new Solution0741_2();
            int[][] grid;
            int result, answer;
            int id = 0;

            // 1. 
            grid = [[0, 1, -1], [1, 0, -1], [1, 1, 1]];
            answer = 5;
            result = solution.CherryPickup(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            grid = [[1, 1, -1], [1, -1, 1], [-1, 1, 1]];
            answer = 0;
            result = solution.CherryPickup(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            grid = [[1, 1, 1, 1, -1, -1, -1, 1, 0, 0], [1, 0, 0, 0, 1, 0, 0, 0, 1, 0],  [0, 0, 1, 1, 1, 1, 0, 1, 1, 1],   [1, 1, 0, 1, 1, 1, 0, -1, 1, 1],  [0, 0, 0, 0, 1, -1, 0, 0, 1, -1],
                    [1, 0, 1, 1, 1, 0, 0, -1, 1, 0],   [1, 1, 0, 1, 0, 0, 1, 0, 1, -1], [1, -1, 0, 1, 0, 0, 0, 1, -1, 1], [1, 0, -1, 0, -1, 0, 0, 1, 0, 0], [0, 0, -1, 0, 1, 0, 1, 0, 0, 1]];
            answer = 22;
            result = solution.CherryPickup(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
