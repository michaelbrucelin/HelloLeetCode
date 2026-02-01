using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1545
{
    public class Test1545
    {
        public void Test()
        {
            Interface1545 solution = new Solution1545_3();
            int n, k;
            char result, answer;
            int id = 0;

            // 1. 
            n = 3; k = 1;
            answer = '0';
            result = solution.FindKthBit(n, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            n = 4; k = 11;
            answer = '1';
            result = solution.FindKthBit(n, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            n = 1; k = 1;
            answer = '0';
            result = solution.FindKthBit(n, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            n = 2; k = 3;
            answer = '1';
            result = solution.FindKthBit(n, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
