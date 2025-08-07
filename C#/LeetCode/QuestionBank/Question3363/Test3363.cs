using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3363
{
    public class Test3363
    {
        public void Test()
        {
            Interface3363 solution = new Solution3363();
            int[][] fruits;
            int result, answer;
            int id = 0;

            // 1. 
            fruits = [[1, 2, 3, 4], [5, 6, 8, 7], [9, 10, 11, 12], [13, 14, 15, 16]];
            answer = 100;
            result = solution.MaxCollectedFruits(fruits);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            fruits = [[1, 1], [1, 1]];
            answer = 4;
            result = solution.MaxCollectedFruits(fruits);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            fruits = [[16, 3, 11, 14, 14], [3, 0, 10, 13, 14], [7, 18, 8, 7, 18], [7, 8, 5, 7, 5], [0, 14, 8, 1, 0]];
            answer = 105;
            result = solution.MaxCollectedFruits(fruits);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
