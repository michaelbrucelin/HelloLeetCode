using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0600
{
    public class Test0600
    {
        public void Test()
        {
            Interface0600 solution = new Solution0600_4();
            int n;
            int result, answer;
            int id = 0;

            // 1. 
            n = 1; answer = 2;
            result = solution.FindIntegers(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            n = 2; answer = 3;
            result = solution.FindIntegers(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            n = 3; answer = 3;
            result = solution.FindIntegers(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            n = 4; answer = 4;
            result = solution.FindIntegers(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            n = 5; answer = 5;
            result = solution.FindIntegers(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 6. 
            n = 8; answer = 6;
            result = solution.FindIntegers(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 7. 
            n = 12345; answer = 987;
            result = solution.FindIntegers(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
