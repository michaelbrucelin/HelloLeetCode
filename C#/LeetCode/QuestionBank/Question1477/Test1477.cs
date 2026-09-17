using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1477
{
    public class Test1477
    {
        public void Test()
        {
            Interface1477 solution = new Solution1477();
            int[] arr; int target;
            int result, answer;
            int id = 0;

            // 1. 
            arr = [3, 2, 2, 4, 3]; target = 3;
            answer = 2;
            result = solution.MinSumOfLengths(arr, target);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            arr = [7, 3, 4, 7]; target = 7;
            answer = 2;
            result = solution.MinSumOfLengths(arr, target);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            arr = [4, 3, 2, 6, 2, 3, 4]; target = 6;
            answer = -1;
            result = solution.MinSumOfLengths(arr, target);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            arr = [5, 5, 4, 4, 5]; target = 3;
            answer = -1;
            result = solution.MinSumOfLengths(arr, target);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            arr = [3, 1, 1, 1, 5, 1, 2, 1]; target = 3;
            answer = 3;
            result = solution.MinSumOfLengths(arr, target);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 6. 
            arr = [1, 1, 1, 2, 2, 2, 4, 4]; target = 6;
            answer = 6;
            result = solution.MinSumOfLengths(arr, target);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 7. 
            arr = [2, 2, 4, 4, 4, 4, 4, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1]; target = 20;
            answer = 23;
            result = solution.MinSumOfLengths(arr, target);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
