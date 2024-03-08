using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2834
{
    public class Test2834
    {
        public void Test()
        {
            Interface2834 solution = new Solution2834();
            int n, target;
            int result, answer;
            int id = 0;

            // 1. 
            n = 2; target = 3;
            answer = 4;
            result = solution.MinimumPossibleSum(n, target);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            n = 3; target = 3;
            answer = 8;
            result = solution.MinimumPossibleSum(n, target);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            n = 1; target = 1;
            answer = 1;
            result = solution.MinimumPossibleSum(n, target);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            n = 1000000000; target = 1000000000;
            answer = 750000042;
            result = solution.MinimumPossibleSum(n, target);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
