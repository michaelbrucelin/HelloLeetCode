using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2232
{
    public class Test2232
    {
        public void Test()
        {
            Interface2232 solution = new Solution2232();
            string expression;
            string result, answer;
            int id = 0;

            // 1. 
            expression = "247+38";
            answer = "2(47+38)";
            result = solution.MinimizeResult(expression);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            expression = "12+34";
            answer = "1(2+3)4";
            result = solution.MinimizeResult(expression);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            expression = "999+999";
            answer = "(999+999)";
            result = solution.MinimizeResult(expression);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            expression = "1+1";
            answer = "(1+1)";
            result = solution.MinimizeResult(expression);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            expression = "45+41";
            answer = "4(5+4)1";
            result = solution.MinimizeResult(expression);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
