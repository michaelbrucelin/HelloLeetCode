using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1155
{
    public class Test1155
    {
        public void Test()
        {
            Interface1155 solution = new Solution1155();
            int n, k, target;
            int result, answer;
            int id = 0;

            // 1. 
            n = 1; k = 6; target = 3;
            answer = 1;
            result = solution.NumRollsToTarget(n, k, target);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            n = 2; k = 6; target = 7;
            answer = 6;
            result = solution.NumRollsToTarget(n, k, target);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            n = 30; k = 30; target = 500;
            answer = 222616187;
            result = solution.NumRollsToTarget(n, k, target);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
