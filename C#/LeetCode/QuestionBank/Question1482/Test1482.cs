using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1482
{
    public class Test1482
    {
        public void Test()
        {
            Interface1482 solution = new Solution1482();
            int[] bloomDay; int m, k;
            int result, answer;
            int id = 0;

            // 1. 
            bloomDay = [1, 10, 3, 10, 2]; m = 3; k = 1;
            answer = 3;
            result = solution.MinDays(bloomDay, m, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            bloomDay = [1, 10, 3, 10, 2]; m = 3; k = 2;
            answer = -1;
            result = solution.MinDays(bloomDay, m, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            bloomDay = [7, 7, 7, 7, 12, 7, 7]; m = 2; k = 3;
            answer = 12;
            result = solution.MinDays(bloomDay, m, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            bloomDay = [1000000000, 1000000000]; m = 1; k = 1;
            answer = 1000000000;
            result = solution.MinDays(bloomDay, m, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            bloomDay = [1, 10, 2, 9, 3, 8, 4, 7, 5, 6]; m = 4; k = 2;
            answer = 9;
            result = solution.MinDays(bloomDay, m, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
