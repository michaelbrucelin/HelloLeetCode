using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0372
{
    public class Test0372
    {
        public void Test()
        {
            Interface0372 solution = new Solution0372();
            int a; int[] b;
            int result, answer;
            int id = 0;

            // 1. 
            a = 2; b = [3];
            answer = 8;
            result = solution.SuperPow(a, b);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            a = 2; b = [1, 0];
            answer = 1024;
            result = solution.SuperPow(a, b);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            a = 1; b = [4, 3, 3, 8, 5, 2];
            answer = 1;
            result = solution.SuperPow(a, b);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            a = 2147483647; b = [2, 0, 0];
            answer = 1198;
            result = solution.SuperPow(a, b);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
