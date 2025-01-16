using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3095
{
    public class Test3095
    {
        public void Test()
        {
            Interface3095 solution = new Solution3095_3();
            int[] nums; int k;
            int result, answer;
            int id = 0;

            // 1. 
            nums = [1, 2, 3]; k = 2;
            answer = 1;
            result = solution.MinimumSubarrayLength(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = [2, 1, 8]; k = 10;
            answer = 3;
            result = solution.MinimumSubarrayLength(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = [1, 2]; k = 0;
            answer = 1;
            result = solution.MinimumSubarrayLength(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            nums = [32, 1, 25, 11, 2]; k = 59;
            answer = 4;
            result = solution.MinimumSubarrayLength(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            nums = [5, 18, 16]; k = 25;
            answer = -1;
            result = solution.MinimumSubarrayLength(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
