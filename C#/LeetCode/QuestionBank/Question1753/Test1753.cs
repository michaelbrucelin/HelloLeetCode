using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1753
{
    public class Test1753
    {
        public void Test()
        {
            Interface1753 solution = new Solution1753_2();
            int a; int b; int c;
            int result, answer;
            int id = 0;

            // 1.
            a = 6; b = 4; c = 2; answer = 6;
            result = solution.MaximumScore(a, b, c);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2.
            a = 4; b = 4; c = 6; answer = 7;
            result = solution.MaximumScore(a, b, c);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3.
            a = 1; b = 8; c = 8; answer = 8;
            result = solution.MaximumScore(a, b, c);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4.
            a = 3; b = 3; c = 3; answer = 4;
            result = solution.MaximumScore(a, b, c);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5.
            a = 5; b = 4; c = 2; answer = 5;
            result = solution.MaximumScore(a, b, c);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
