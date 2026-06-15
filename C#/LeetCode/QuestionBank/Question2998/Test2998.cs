using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2998
{
    public class Test2998
    {
        public void Test()
        {
            Interface2998 solution = new Solution2998();
            int x, y;
            int result, answer;
            int id = 0;

            // 1. 
            x = 26; y = 1;
            answer = 3;
            result = solution.MinimumOperationsToMakeEqual(x, y);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            x = 54; y = 2;
            answer = 4;
            result = solution.MinimumOperationsToMakeEqual(x, y);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            x = 25; y = 30;
            answer = 5;
            result = solution.MinimumOperationsToMakeEqual(x, y);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
