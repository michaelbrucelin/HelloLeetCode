using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3139
{
    public class Test3139
    {
        public void Test()
        {
            Interface3139 solution = new Solution3139_err();
            int[] nums; int cost1, cost2;
            int result, answer;
            int id = 0;

            // 1. 
            nums = [4, 1]; cost1 = 5; cost2 = 2;
            answer = 15;
            result = solution.MinCostToEqualizeArray(nums, cost1, cost2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = [2, 3, 3, 3, 5]; cost1 = 2; cost2 = 1;
            answer = 6;
            result = solution.MinCostToEqualizeArray(nums, cost1, cost2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = [3, 5, 3]; cost1 = 1; cost2 = 3;
            answer = 4;
            result = solution.MinCostToEqualizeArray(nums, cost1, cost2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            nums = [1, 14, 14, 15]; cost1 = 2; cost2 = 1;
            answer = 20;
            result = solution.MinCostToEqualizeArray(nums, cost1, cost2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
