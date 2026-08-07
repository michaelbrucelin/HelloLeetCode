using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1996
{
    public class Test1996
    {
        public void Test()
        {
            Interface1996 solution = new Solution1996();
            int[][] properties;
            int result, answer;
            int id = 0;

            // 1. 
            properties = [[5, 5], [6, 3], [3, 6]];
            answer = 0;
            result = solution.NumberOfWeakCharacters(properties);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            properties = [[2, 2], [3, 3]];
            answer = 1;
            result = solution.NumberOfWeakCharacters(properties);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            properties = [[1, 5], [10, 4], [4, 3]];
            answer = 1;
            result = solution.NumberOfWeakCharacters(properties);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            properties = [[7, 9], [10, 7], [6, 9], [10, 4], [7, 5], [7, 10]];
            answer = 2;
            result = solution.NumberOfWeakCharacters(properties);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            properties = [[6, 6], [6, 6], [6, 6], [6, 6], [6, 6], [6, 6], [6, 6], [6, 6], [6, 6]];
            answer = 0;
            result = solution.NumberOfWeakCharacters(properties);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
