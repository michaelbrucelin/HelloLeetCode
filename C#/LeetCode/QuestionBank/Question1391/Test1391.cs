using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1391
{
    public class Test1391
    {
        public void Test()
        {
            Interface1391 solution = new Solution1391();
            int[][] grid; bool result, answer;
            int id = 0;

            // 1. 
            grid = [[2, 4, 3], [6, 5, 2]];
            answer = true;
            result = solution.HasValidPath(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            grid = [[1, 2, 1], [1, 2, 1]];
            answer = false;
            result = solution.HasValidPath(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            grid = [[1, 1, 2]];
            answer = false;
            result = solution.HasValidPath(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            grid = [[1, 1, 1, 1, 1, 1, 3]];
            answer = true;
            result = solution.HasValidPath(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            grid = [[2], [2], [2], [2], [2], [2], [6]];
            answer = true;
            result = solution.HasValidPath(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 6. 
            grid = [[4, 1], [6, 1]];
            answer = true;
            result = solution.HasValidPath(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 7. 
            grid = [[6, 1, 3], [4, 1, 5]];
            answer = true;
            result = solution.HasValidPath(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 8. 
            grid = [[3, 4, 3, 4], [2, 2, 2, 2], [6, 5, 6, 5]];
            answer = true;
            result = solution.HasValidPath(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
