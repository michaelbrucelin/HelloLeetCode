using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3209
{
    public class Test3209
    {
        public void Test()
        {
            Interface3209 solution = new Solution3209();
            int[] nums; int k;
            long result, answer;
            int id = 0;

            // 1. 
            nums = [1, 1, 1]; k = 1;
            answer = 6;
            result = solution.CountSubarrays(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = [1, 1, 2]; k = 1;
            answer = 3;
            result = solution.CountSubarrays(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = [1, 2, 3]; k = 2;
            answer = 2;
            result = solution.CountSubarrays(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            nums = [1, 9, 9, 7, 4]; k = 1;
            answer = 6;
            result = solution.CountSubarrays(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
