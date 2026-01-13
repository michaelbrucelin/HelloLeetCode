using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3453
{
    public class Test3453
    {
        public void Test()
        {
            Interface3453 solution = new Solution3453();
            int[][] squares;
            double result, answer;
            int id = 0;

            // 1. 
            squares = [[0, 0, 1], [2, 2, 1]];
            answer = 1.00000;
            result = solution.SeparateSquares(squares);
            Console.WriteLine($"{++id,2}: {(Math.Abs(result - answer) <= Math.Pow(10d, -5)) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            squares = [[0, 0, 2], [1, 1, 1]];
            answer = 1.16667;
            result = solution.SeparateSquares(squares);
            Console.WriteLine($"{++id,2}: {(Math.Abs(result - answer) <= Math.Pow(10d, -5)) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
