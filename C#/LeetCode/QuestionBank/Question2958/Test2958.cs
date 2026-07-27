using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2958
{
    public class Test2958
    {
        public void Test()
        {
            Interface2958 solution = new Solution2958();
            int[] nums; int k;
            int result, answer;
            int id = 0;

            // 1. 
            nums = [1, 2, 3, 1, 2, 3, 1, 2]; k = 2;
            answer = 6;
            result = solution.MaxSubarrayLength(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = [1, 2, 1, 2, 1, 2, 1, 2]; k = 1;
            answer = 2;
            result = solution.MaxSubarrayLength(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = [5, 5, 5, 5, 5, 5, 5]; k = 4;
            answer = 4;
            result = solution.MaxSubarrayLength(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
