using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1536
{
    public class Test1536
    {
        public void Test()
        {
            Interface1536 solution = new Solution1536();
            int[][] grid;
            int result, answer;
            int id = 0;

            // 1. 
            grid = [[0, 0, 1], [1, 1, 0], [1, 0, 0]];
            answer = 3;
            result = solution.MinSwaps(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            grid = [[0, 1, 1, 0], [0, 1, 1, 0], [0, 1, 1, 0], [0, 1, 1, 0]];
            answer = -1;
            result = solution.MinSwaps(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            grid = [[1, 0, 0], [1, 1, 0], [1, 1, 1]];
            answer = 0;
            result = solution.MinSwaps(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
