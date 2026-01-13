using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0861
{
    public class Test0861
    {
        public void Test()
        {
            Interface0861 solution = new Solution0861();
            int[][] grid;
            int result, answer;
            int id = 0;

            // 1. 
            grid = [[0, 0, 1, 1], [1, 0, 1, 0], [1, 1, 0, 0]];
            answer = 39;
            result = solution.MatrixScore(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            grid = [[0]];
            answer = 1;
            result = solution.MatrixScore(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
