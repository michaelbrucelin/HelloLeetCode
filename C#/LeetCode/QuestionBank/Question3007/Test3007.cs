using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3007
{
    public class Test3007
    {
        public void Test()
        {
            Interface3007 solution = new Solution3007();
            long k; int x;
            long result, answer;
            int id = 0;

            // 1. 
            k = 9; x = 1;
            answer = 6;
            result = solution.FindMaximumNumber(k, x);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            k = 7; x = 2;
            answer = 9;
            result = solution.FindMaximumNumber(k, x);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            k = 19; x = 6;
            answer = 50;
            result = solution.FindMaximumNumber(k, x);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            k = 4096; x = 6;
            answer = 4127;
            result = solution.FindMaximumNumber(k, x);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            k = 3278539330613; x = 5;
            answer = 851568447023;
            result = solution.FindMaximumNumber(k, x);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
