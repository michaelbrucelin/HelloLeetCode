using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1156
{
    public class Test1156
    {
        public void Test()
        {
            Interface1156 solution = new Solution1156();
            string text;
            int result, answer;
            int id = 0;

            // 1. 
            text = "ababa"; answer = 3;
            result = solution.MaxRepOpt1(text);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            text = "aaabaaa"; answer = 6;
            result = solution.MaxRepOpt1(text);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            text = "aaabbaaa"; answer = 4;
            result = solution.MaxRepOpt1(text);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            text = "aaaaa"; answer = 5;
            result = solution.MaxRepOpt1(text);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            text = "abcdef"; answer = 1;
            result = solution.MaxRepOpt1(text);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
