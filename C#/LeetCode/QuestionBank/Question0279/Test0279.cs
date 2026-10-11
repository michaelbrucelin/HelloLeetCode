using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0279
{
    public class Test0279
    {
        public void Test()
        {
            Interface0279 solution = new Solution0279();
            int n;
            int result, answer;
            int id = 0;

            // 1. 
            n = 12;
            answer = 3;
            result = solution.NumSquares(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            n = 13;
            answer = 2;
            result = solution.NumSquares(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
