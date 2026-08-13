using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3738
{
    public class Test3738
    {
        public void Test()
        {
            Interface3738 solution = new Solution3738();
            int[] nums;
            int result, answer;
            int id = 0;

            // 1. 
            nums = [1, 2, 3, 1, 2];
            answer = 4;
            result = solution.LongestSubarray(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = [2, 2, 2, 2, 2];
            answer = 5;
            result = solution.LongestSubarray(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = [8, -8];
            answer = 2;
            result = solution.LongestSubarray(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
