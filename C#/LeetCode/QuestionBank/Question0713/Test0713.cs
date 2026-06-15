using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0713
{
    public class Test0713
    {
        public void Test()
        {
            Interface0713 solution = new Solution0713();
            int[] nums; int k;
            int result, answer;
            int id = 0;

            // 1. 
            nums = [10, 5, 2, 6]; k = 100;
            answer = 8;
            result = solution.NumSubarrayProductLessThanK(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = [1, 2, 3]; k = 0;
            answer = 0;
            result = solution.NumSubarrayProductLessThanK(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = [1, 1, 1]; k = 1;
            answer = 0;
            result = solution.NumSubarrayProductLessThanK(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            nums = [57, 44, 92, 28, 66, 60, 37, 33, 52, 38, 29, 76, 8, 75, 22]; k = 18;
            answer = 1;
            result = solution.NumSubarrayProductLessThanK(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
