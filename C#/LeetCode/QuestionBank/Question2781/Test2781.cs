using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2781
{
    public class Test2781
    {
        public void Test()
        {
            Interface2781 solution = new Solution2781_err();
            int[] nums;
            int result, answer;
            int id = 0;

            // 1. 
            nums = [1, 0, 2, 0, 1, 2];
            answer = 3;
            result = solution.MaxSubarrays(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = [5, 7, 1, 3];
            answer = 1;
            result = solution.MaxSubarrays(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = [22, 21, 29, 22];
            answer = 1;
            result = solution.MaxSubarrays(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
