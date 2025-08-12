using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2787
{
    public class Test2787
    {
        public void Test()
        {
            Interface2787 solution = new Solution2787_2();
            int n, x;
            int result, answer;
            int id = 0;

            // 1. 
            n = 10; x = 2;
            answer = 1;
            result = solution.NumberOfWays(n, x);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            n = 4; x = 1;
            answer = 2;
            result = solution.NumberOfWays(n, x);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            n = 1; x = 2;
            answer = 1;
            result = solution.NumberOfWays(n, x);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
