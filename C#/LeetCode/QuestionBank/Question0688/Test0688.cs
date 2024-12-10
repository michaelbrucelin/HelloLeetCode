using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0688
{
    public class Test0688
    {
        public void Test()
        {
            Interface0688 solution = new Solution0688_2();
            int n, k, row, column;
            double result, answer;
            int id = 0;

            // 1. 
            n = 3; k = 2; row = 0; column = 0;
            answer = 0.0625;
            result = solution.KnightProbability(n, k, row, column);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            n = 1; k = 0; row = 0; column = 0;
            answer = 1.00000;
            result = solution.KnightProbability(n, k, row, column);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3.
            n = 8; k = 30; row = 6; column = 4;
            answer = 0.00019;
            result = solution.KnightProbability(n, k, row, column);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
