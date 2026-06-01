using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3429
{
    public class Test3429
    {
        public void Test()
        {
            Interface3429 solution = new Solution3429();
            int n; int[][] cost;
            long result, answer;
            int id = 0;

            // 1. 
            n = 4; cost = [[3, 5, 7], [6, 2, 9], [4, 8, 1], [7, 3, 5]];
            answer = 9;
            result = solution.MinCost(n, cost);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            n = 6; cost = [[2, 4, 6], [5, 3, 8], [7, 1, 9], [4, 6, 2], [3, 5, 7], [8, 2, 4]];
            answer = 18;
            result = solution.MinCost(n, cost);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
