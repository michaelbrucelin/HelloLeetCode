using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2908
{
    public class Test2908
    {
        public void Test()
        {
            Interface2908 solution = new Solution2908_2();
            int[] nums;
            int result, answer;
            int id = 0;

            // 1. 
            nums = new int[] { 8, 6, 1, 5, 3 };
            answer = 9;
            result = solution.MinimumSum(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = new int[] { 5, 4, 8, 7, 10, 2 };
            answer = 13;
            result = solution.MinimumSum(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = new int[] { 6, 5, 4, 3, 4, 5 };
            answer = -1;
            result = solution.MinimumSum(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
