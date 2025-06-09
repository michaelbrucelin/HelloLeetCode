using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0440
{
    public class Test0440
    {
        public void Test()
        {
            Interface0440 solution = new Solution0440();
            int n, k;
            int result, answer;
            int id = 0;

            // 1. 
            n = 13; k = 2;
            answer = 10;
            result = solution.FindKthNumber(n, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            n = 1; k = 1;
            answer = 1;
            result = solution.FindKthNumber(n, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            n = 100; k = 13;
            answer = 2;
            result = solution.FindKthNumber(n, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            n = 100; k = 90;
            answer = 9;
            result = solution.FindKthNumber(n, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            n = 681692778; k = 351251360;
            answer = 416126219;
            result = solution.FindKthNumber(n, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
