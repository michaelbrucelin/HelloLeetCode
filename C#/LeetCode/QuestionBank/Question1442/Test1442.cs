using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1442
{
    public class Test1442
    {
        public void Test()
        {
            Interface1442 solution = new Solution1442();
            int[] arr;
            int result, answer;
            int id = 0;

            // 1. 
            arr = [2, 3, 1, 6, 7];
            answer = 4;
            result = solution.CountTriplets(arr);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            arr = [1, 1, 1, 1, 1];
            answer = 10;
            result = solution.CountTriplets(arr);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            arr = [2, 3];
            answer = 0;
            result = solution.CountTriplets(arr);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            arr = [1, 3, 5, 7, 9];
            answer = 3;
            result = solution.CountTriplets(arr);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            arr = [7, 11, 12, 9, 5, 2, 7, 17, 22];
            answer = 8;
            result = solution.CountTriplets(arr);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
