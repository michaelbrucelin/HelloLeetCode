using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2327
{
    public class Test2327
    {
        public void Test()
        {
            Interface2327 solution = new Solution2327();
            int n, delay, forget;
            int result, answer;
            int id = 0;

            // 1. 
            n = 6; delay = 2; forget = 4;
            answer = 5;
            result = solution.PeopleAwareOfSecret(n, delay, forget);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            n = 4; delay = 1; forget = 3;
            answer = 6;
            result = solution.PeopleAwareOfSecret(n, delay, forget);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            n = 684; delay = 18; forget = 496;
            answer = 653668527;
            result = solution.PeopleAwareOfSecret(n, delay, forget);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
