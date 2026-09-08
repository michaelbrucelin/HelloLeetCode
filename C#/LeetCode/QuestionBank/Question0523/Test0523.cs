using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0523
{
    public class Test0523
    {
        public void Test()
        {
            Interface0523 solution = new Solution0523();
            int[] nums; int k;
            bool result, answer;
            int id = 0;

            // 1. 
            nums = [23, 2, 4, 6, 7]; k = 6;
            answer = true;
            result = solution.CheckSubarraySum(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = [23, 2, 6, 4, 7]; k = 6;
            answer = true;
            result = solution.CheckSubarraySum(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = [23, 2, 6, 4, 7]; k = 13;
            answer = false;
            result = solution.CheckSubarraySum(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            nums = [23, 2, 4, 6, 6]; k = 7;
            answer = true;
            result = solution.CheckSubarraySum(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            nums = [1, 2, 12]; k = 6;
            answer = false;
            result = solution.CheckSubarraySum(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
