using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0918
{
    public class Test0918
    {
        public void Test()
        {
            Interface0918 solution = new Solution0918();
            int[] nums;
            int result, answer;
            int id = 0;

            // 1. 
            nums = new int[] { 1, -2, 3, -2 };
            answer = 3;
            result = solution.MaxSubarraySumCircular(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            //2 . 
            nums = new int[] { 5, -3, 5 };
            answer = 10;
            result = solution.MaxSubarraySumCircular(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = new int[] { 3, -2, 2, -3 };
            answer = 3;
            result = solution.MaxSubarraySumCircular(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            nums = new int[] { -3, -2, -3 };
            answer = -2;
            result = solution.MaxSubarraySumCircular(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
