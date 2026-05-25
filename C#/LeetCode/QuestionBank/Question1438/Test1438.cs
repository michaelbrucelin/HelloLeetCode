using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1438
{
    public class Test1438
    {
        public void Test()
        {
            Interface1438 solution = new Solution1438();
            int[] nums; int limit;
            int result, answer;
            int id = 0;

            // 1. 
            nums = [8, 2, 4, 7]; limit = 4;
            answer = 2;
            result = solution.LongestSubarray(nums, limit);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = [10, 1, 2, 4, 7, 2]; limit = 5;
            answer = 4;
            result = solution.LongestSubarray(nums, limit);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = [4, 2, 2, 2, 4, 4, 2, 2]; limit = 0;
            answer = 3;
            result = solution.LongestSubarray(nums, limit);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
