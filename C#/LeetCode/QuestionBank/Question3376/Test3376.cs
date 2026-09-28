using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3376
{
    public class Test3376
    {
        public void Test()
        {
            Interface3376 solution = new Solution3376_err();
            IList<int> strength; int k;
            int result, answer;
            int id = 0;

            // 1. 
            strength = [3, 4, 1]; k = 1;
            answer = 4;
            result = solution.FindMinimumTime(strength, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            strength = [2, 5, 4]; k = 2;
            answer = 5;
            result = solution.FindMinimumTime(strength, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            strength = [7, 3, 6, 18, 22, 50]; k = 4;
            answer = 12;
            result = solution.FindMinimumTime(strength, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
