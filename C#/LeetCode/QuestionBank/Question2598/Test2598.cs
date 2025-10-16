using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2598
{
    public class Test2598
    {
        public void Test()
        {
            Interface2598 solution = new Solution2598();
            int[] nums; int value;
            int result, answer;
            int id = 0;

            // 1. 
            nums = [1, -10, 7, 13, 6, 8]; value = 5;
            answer = 4;
            result = solution.FindSmallestInteger(nums, value);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = [1, -10, 7, 13, 6, 8]; value = 7;
            answer = 2;
            result = solution.FindSmallestInteger(nums, value);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = [3, 0, 3, 2, 4, 2, 1, 1, 0, 4]; value = 5;
            answer = 10;
            result = solution.FindSmallestInteger(nums, value);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            nums = [3, 2, 3, 1, 0, 1, 4, 2, 3, 1, 4, 1, 3]; value = 5;
            answer = 5;
            result = solution.FindSmallestInteger(nums, value);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
