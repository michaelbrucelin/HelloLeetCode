using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1269
{
    public class Test1269
    {
        public void Test()
        {
            Interface1269 solution = new Solution1269();
            int steps, arrLen;
            int result, answer;
            int id = 0;

            // 1. 
            steps = 3; arrLen = 2;
            answer = 4;
            result = solution.NumWays(steps, arrLen);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            steps = 2; arrLen = 4;
            answer = 2;
            result = solution.NumWays(steps, arrLen);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            steps = 4; arrLen = 2;
            answer = 8;
            result = solution.NumWays(steps, arrLen);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
