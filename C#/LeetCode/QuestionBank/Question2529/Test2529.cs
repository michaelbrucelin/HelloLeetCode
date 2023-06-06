using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2529
{
    public class Test2529
    {
        public void Test()
        {
            Interface2529 solution = new Solution2529_api();
            int[] nums;
            int result, answer;
            int id = 0;

            // 1. 
            nums = new int[] { -2, -1, -1, 1, 2, 3 };
            answer = 3;
            result = solution.MaximumCount(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = new int[] { -3, -2, -1, 0, 0, 1, 2 };
            answer = 3;
            result = solution.MaximumCount(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = new int[] { 5, 20, 66, 1314 };
            answer = 4;
            result = solution.MaximumCount(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
