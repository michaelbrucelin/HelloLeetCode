using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2762
{
    public class Test2762
    {
        public void Test()
        {
            Interface2762 solution = new Solution2762_2();
            int[] nums;
            long result, answer;
            int id = 0;

            // 1. 
            nums = [5, 4, 2, 4];
            answer = 8;
            result = solution.ContinuousSubarrays(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = [1, 2, 3];
            answer = 6;
            result = solution.ContinuousSubarrays(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = [3, 2, 6];
            answer = 4;
            result = solution.ContinuousSubarrays(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
