using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3700
{
    public class Test3700
    {
        public void Test()
        {
            Interface3700 solution = new Solution3700();
            int n, l, r;
            int result, answer;
            int id = 0;

            // 1. 
            n = 3; l = 4; r = 5;
            answer = 2;
            result = solution.ZigZagArrays(n, l, r);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            n = 3; l = 1; r = 3;
            answer = 10;
            result = solution.ZigZagArrays(n, l, r);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            n = 5047110; l = 1; r = 34;
            answer = 301291631;
            result = solution.ZigZagArrays(n, l, r);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            n = 81482900; l = 31; r = 33;
            answer = 551374482;
            result = solution.ZigZagArrays(n, l, r);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
