using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2302
{
    public class Test2302
    {
        public void Test()
        {
            Interface2302 solution = new Solution2302_2();
            int[] nums; long k;
            long result, answer;
            int id = 0;

            // 1. 
            nums = [2, 1, 4, 3, 5]; k = 10;
            answer = 6;
            result = solution.CountSubarrays(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = [1, 1, 1]; k = 5;
            answer = 5;
            result = solution.CountSubarrays(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
