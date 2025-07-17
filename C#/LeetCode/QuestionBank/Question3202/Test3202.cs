using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3202
{
    public class Test3202
    {
        public void Test()
        {
            Interface3202 solution = new Solution3202();
            int[] nums; int k;
            int result, answer;
            int id = 0;

            // 1. 
            nums = [1, 2, 3, 4, 5]; k = 2;
            answer = 5;
            result = solution.MaximumLength(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = [1, 4, 2, 3, 1, 4]; k = 3;
            answer = 4;
            result = solution.MaximumLength(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
