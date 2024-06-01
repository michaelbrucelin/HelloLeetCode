using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2928
{
    public class Test2928
    {
        public void Test()
        {
            Interface2928 solution = new Solution2928();
            int n, limit;
            int result, answer;
            int id = 0;

            // 1. 
            n = 5; limit = 2;
            answer = 3;
            result = solution.DistributeCandies(n, limit);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            n = 3; limit = 3;
            answer = 10;
            result = solution.DistributeCandies(n, limit);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            n = 1; limit = 3;
            answer = 3;
            result = solution.DistributeCandies(n, limit);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
