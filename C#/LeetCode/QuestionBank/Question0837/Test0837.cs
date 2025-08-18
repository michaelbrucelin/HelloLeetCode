using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0837
{
    public class Test0837
    {
        public void Test()
        {
            Interface0837 solution = new Solution0837();
            int n, k, maxPts;
            double result, answer;
            int id = 0;

            // 1. 
            n = 10; k = 1; maxPts = 10;
            answer = 1.00000D;
            result = solution.New21Game(n, k, maxPts);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            n = 6; k = 1; maxPts = 10;
            answer = 0.60000D;
            result = solution.New21Game(n, k, maxPts);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            n = 21; k = 17; maxPts = 10;
            answer = 0.73278D;
            result = solution.New21Game(n, k, maxPts);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            n = 0; k = 0; maxPts = 2;
            answer = 1.00000D;
            result = solution.New21Game(n, k, maxPts);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5.
            n = 9811; k = 8776; maxPts = 1096;
            answer = 0.99696D;
            result = solution.New21Game(n, k, maxPts);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
