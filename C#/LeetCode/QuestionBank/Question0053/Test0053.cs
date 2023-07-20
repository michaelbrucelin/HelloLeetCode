using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0053
{
    public class Test0053
    {
        public void Test()
        {
            Interface0053 solution = new Solution0053();
            int[] nums;
            int result, answer;
            int id = 0;

            // 1. 
            nums = new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
            answer = 6;
            result = solution.MaxSubArray(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = new int[] { 1 };
            answer = 1;
            result = solution.MaxSubArray(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = new int[] { 5, 4, -1, 7, 8 };
            answer = 23;
            result = solution.MaxSubArray(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            nums = new int[] { -1 };
            answer = -1;
            result = solution.MaxSubArray(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            nums = new int[] { 8, -19, 5, -4, 20 };
            answer = 21;
            result = solution.MaxSubArray(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
