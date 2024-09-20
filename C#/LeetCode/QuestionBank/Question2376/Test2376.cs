using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2376
{
    public class Test2376
    {
        public void Test()
        {
            Interface2376 solution = new Solution2376();
            int n;
            int result, answer;
            int id = 0;

            // 1. 
            n = 20;
            answer = 19;
            result = solution.CountSpecialNumbers(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            n = 5;
            answer = 5;
            result = solution.CountSpecialNumbers(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            n = 135;
            answer = 110;
            result = solution.CountSpecialNumbers(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            n = 12306;
            answer = 5655;
            result = solution.CountSpecialNumbers(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            n = 10086;
            answer = 5274;
            result = solution.CountSpecialNumbers(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}