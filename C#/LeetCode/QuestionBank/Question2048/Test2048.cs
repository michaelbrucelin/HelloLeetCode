using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2048
{
    public class Test2048
    {
        public void Test()
        {
            Interface2048 solution = new Solution2048_2();
            int n;
            int result, answer;
            int id = 0;

            // 1. 
            n = 1;
            answer = 22;
            result = solution.NextBeautifulNumber(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            n = 1000;
            answer = 1333;
            result = solution.NextBeautifulNumber(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            n = 3000;
            answer = 3133;
            result = solution.NextBeautifulNumber(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            n = 1000000;
            answer = 1224444;
            result = solution.NextBeautifulNumber(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
