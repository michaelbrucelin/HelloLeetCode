using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1553
{
    public class Test1553
    {
        public void Test()
        {
            Interface1553 solution = new Solution1553_4();
            int n;
            int result, answer;
            int id = 0;

            // 1. 
            n = 10;
            answer = 4;
            result = solution.MinDays(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            n = 6;
            answer = 3;
            result = solution.MinDays(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            n = 1;
            answer = 1;
            result = solution.MinDays(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            n = 56;
            answer = 6;
            result = solution.MinDays(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            n = 880;
            answer = 10;
            result = solution.MinDays(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 6. 
            n = 820592;
            answer = 22;
            result = solution.MinDays(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 7. 
            n = 61455274;
            answer = 29;
            result = solution.MinDays(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 8. 
            n = 8;
            answer = 4;
            result = solution.MinDays(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
