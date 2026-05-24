using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1340
{
    public class Test1340
    {
        public void Test()
        {
            Interface1340 solution = new Solution1340();
            int[] arr; int d;
            int result, answer;
            int id = 0;

            // 1. 
            arr = [6, 4, 14, 6, 8, 13, 9, 7, 10, 6, 12]; d = 2;
            answer = 4;
            result = solution.MaxJumps(arr, d);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            arr = [3, 3, 3, 3, 3]; d = 3;
            answer = 1;
            result = solution.MaxJumps(arr, d);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            arr = [7, 6, 5, 4, 3, 2, 1]; d = 1;
            answer = 7;
            result = solution.MaxJumps(arr, d);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            arr = [7, 1, 7, 1, 7, 1]; d = 2;
            answer = 2;
            result = solution.MaxJumps(arr, d);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            arr = [66]; d = 1;
            answer = 1;
            result = solution.MaxJumps(arr, d);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
