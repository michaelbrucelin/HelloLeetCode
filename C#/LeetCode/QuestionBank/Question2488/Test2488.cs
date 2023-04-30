using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2488
{
    public class Test2488
    {
        public void Test()
        {
            Interface2488 solution = new Solution2488_2();
            int[] nums; int k;
            int result, answer;
            int id = 0;

            // 1. 
            nums = new int[] { 3, 2, 1, 4, 5 }; k = 4; answer = 3;
            result = solution.CountSubarrays(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = new int[] { 2, 3, 1 }; k = 3; answer = 1;
            result = solution.CountSubarrays(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = new int[] { 1 }; k = 1; answer = 1;
            result = solution.CountSubarrays(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            nums = new int[] { 2, 5, 1, 4, 3, 6 }; k = 1; answer = 3;
            result = solution.CountSubarrays(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
