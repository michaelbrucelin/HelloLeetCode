using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3047
{
    public class Test3047
    {
        public void Test()
        {
            Interface3047 solution = new Solution3047();
            int[][] bottomLeft, topRight;
            long result, answer;
            int id = 0;

            // 1. 
            bottomLeft = [[1, 1], [2, 2], [3, 1]]; topRight = [[3, 3], [4, 4], [6, 6]];
            answer = 1;
            result = solution.LargestSquareArea(bottomLeft, topRight);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            bottomLeft = [[1, 1], [2, 2], [1, 2]]; topRight = [[3, 3], [4, 4], [3, 4]];
            answer = 1;
            result = solution.LargestSquareArea(bottomLeft, topRight);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            bottomLeft = [[1, 1], [3, 3], [3, 1]]; topRight = [[2, 2], [4, 4], [4, 2]];
            answer = 0;
            result = solution.LargestSquareArea(bottomLeft, topRight);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            bottomLeft = [[1, 1], [1, 3], [1, 5]]; topRight = [[5, 5], [5, 7], [5, 9]];
            answer = 4;
            result = solution.LargestSquareArea(bottomLeft, topRight);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
