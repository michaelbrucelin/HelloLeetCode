using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2749
{
    public class Test2749
    {
        public void Test()
        {
            Interface2749 solution = new Solution2749();
            int num1, num2;
            int result, answer;
            int id = 0;

            // 1. 
            num1 = 3; num2 = -2;
            answer = 3;
            result = solution.MakeTheIntegerZero(num1, num2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            num1 = 5; num2 = 7;
            answer = -1;
            result = solution.MakeTheIntegerZero(num1, num2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            num1 = 112577768; num2 = -501662198;
            answer = 16;
            result = solution.MakeTheIntegerZero(num1, num2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
