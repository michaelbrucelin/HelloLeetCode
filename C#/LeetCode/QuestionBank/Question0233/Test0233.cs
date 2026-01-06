using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0233
{
    public class Test0233
    {
        public void Test()
        {
            Interface0233 solution = new Solution0233();
            int n;
            int result, answer;
            int id = 0;

            // 1. 
            n = 13;
            answer = 6;
            result = solution.CountDigitOne(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            n = 0;
            answer = 0;
            result = solution.CountDigitOne(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            n = 23;
            answer = 13;
            result = solution.CountDigitOne(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            n = 824883294;
            answer = 767944060;
            result = solution.CountDigitOne(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
