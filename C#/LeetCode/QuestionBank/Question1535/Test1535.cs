using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1535
{
    public class Test1535
    {
        public void Test()
        {
            Interface1535 solution = new Solution1535();
            int[] arr; int k;
            int result, answer;
            int id = 0;

            // 1. 
            arr = [2, 1, 3, 5, 4, 6, 7]; k = 2;
            answer = 5;
            result = solution.GetWinner(arr, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            arr = [3, 2, 1]; k = 10;
            answer = 3;
            result = solution.GetWinner(arr, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            arr = [1, 9, 8, 2, 3, 7, 6, 4, 5]; k = 7;
            answer = 9;
            result = solution.GetWinner(arr, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            arr = [1, 11, 22, 33, 44, 55, 66, 77, 88, 99]; k = 1000000000;
            answer = 99;
            result = solution.GetWinner(arr, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            arr = [1, 25, 35, 42, 68, 70]; k = 1;
            answer = 25;
            result = solution.GetWinner(arr, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
