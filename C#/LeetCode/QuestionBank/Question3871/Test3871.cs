using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3871
{
    public class Test3871
    {
        public void Test()
        {
            Interface3871 solution = new Solution3871();
            long n;
            long result, answer;
            int id = 0;

            // 1. 
            n = 1002;
            answer = 3;
            result = solution.CountCommas(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            n = 998;
            answer = 0;
            result = solution.CountCommas(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            n = 10010;
            answer = 9011;
            result = solution.CountCommas(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
