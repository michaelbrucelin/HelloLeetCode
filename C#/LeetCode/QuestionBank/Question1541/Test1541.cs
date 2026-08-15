using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1541
{
    public class Test1541
    {
        public void Test()
        {
            Interface1541 solution = new Solution1541();
            string s;
            int result, answer;
            int id = 0;

            // 1. 
            s = "(()))";
            answer = 1;
            result = solution.MinInsertions(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            s = "())";
            answer = 0;
            result = solution.MinInsertions(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            s = "))())(";
            answer = 3;
            result = solution.MinInsertions(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            s = "((((((";
            answer = 12;
            result = solution.MinInsertions(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            s = ")))))))";
            answer = 5;
            result = solution.MinInsertions(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 6. 
            s = "(()))(()))()())))";
            answer = 4;
            result = solution.MinInsertions(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
