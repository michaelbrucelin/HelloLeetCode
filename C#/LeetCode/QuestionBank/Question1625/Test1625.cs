using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1625
{
    public class Test1625
    {
        public void Test()
        {
            Interface1625 solution = new Solution1625_2();
            string s; int a, b;
            string result, answer;
            int id = 0;

            // 1. 
            s = "5525"; a = 9; b = 2;
            answer = "2050";
            result = solution.FindLexSmallestString(s, a, b);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            s = "74"; a = 5; b = 1;
            answer = "24";
            result = solution.FindLexSmallestString(s, a, b);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            s = "0011"; a = 4; b = 2;
            answer = "0011";
            result = solution.FindLexSmallestString(s, a, b);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            s = "43987654"; a = 7; b = 3;
            answer = "00553311";
            result = solution.FindLexSmallestString(s, a, b);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            s = "593290172167"; a = 7; b = 4;
            answer = "206658319916";
            result = solution.FindLexSmallestString(s, a, b);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
