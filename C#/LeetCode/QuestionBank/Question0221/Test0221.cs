using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0221
{
    public class Test0221
    {
        public void Test()
        {
            Interface0221 solution = new Solution0221_2();
            char[][] matrix;
            int result, answer;
            int id = 0;

            // 1. 
            matrix = [['1', '0', '1', '0', '0'], ['1', '0', '1', '1', '1'], ['1', '1', '1', '1', '1'], ['1', '0', '0', '1', '0']];
            answer = 4;
            result = solution.MaximalSquare(matrix);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            matrix = [['0', '1'], ['1', '0']];
            answer = 1;
            result = solution.MaximalSquare(matrix);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            matrix = [['0']];
            answer = 0;
            result = solution.MaximalSquare(matrix);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
