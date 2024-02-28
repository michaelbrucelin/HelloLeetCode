using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2673
{
    public class Test2673
    {
        public void Test()
        {
            Interface2673 solution = new Solution2673_off();
            int n; int[] cost;
            int result, answer;
            int id = 0;

            // 1. 
            n = 7; cost = new int[] { 1, 5, 2, 2, 3, 3, 1 };
            answer = 6;
            result = solution.MinIncrements(n, cost);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            n = 3; cost = new int[] { 5, 3, 3 };
            answer = 0;
            result = solution.MinIncrements(n, cost);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
