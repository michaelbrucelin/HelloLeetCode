using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2240
{
    public class Test2240
    {
        public void Test()
        {
            Interface2240 solution = new Solution2240_err();
            int total, cost1, cost2;
            long result, answer;
            int id = 0;

            // 1. 
            total = 20; cost1 = 10; cost2 = 5;
            answer = 9;
            result = solution.WaysToBuyPensPencils(total, cost1, cost2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            total = 5; cost1 = 10; cost2 = 10;
            answer = 1;
            result = solution.WaysToBuyPensPencils(total, cost1, cost2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            total = 1000000; cost1 = 1; cost2 = 1;
            answer = 500001500001;
            result = solution.WaysToBuyPensPencils(total, cost1, cost2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            total = 10; cost1 = 2; cost2 = 5;
            answer = 10;
            result = solution.WaysToBuyPensPencils(total, cost1, cost2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
