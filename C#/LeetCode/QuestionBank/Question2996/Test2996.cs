using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2996
{
    public class Test2996
    {
        public void Test()
        {
            Interface2996 solution = new Solution2996();
            int[] nums;
            int result, answer;
            int id = 0;

            // 1. 
            nums = new int[] { 1, 2, 3, 2, 5 };
            answer = 6;
            result = solution.MissingInteger(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = new int[] { 3, 4, 5, 1, 12, 14, 13 };
            answer = 15;
            result = solution.MissingInteger(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = new int[] { 4, 5, 6, 7, 8, 8, 9, 4, 3, 2, 7 };
            answer = 30;
            result = solution.MissingInteger(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            nums = new int[] { 29, 30, 31, 32, 33, 34, 35, 36, 37 };
            answer = 297;
            result = solution.MissingInteger(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            nums = new int[] { 38 };
            answer = 39;
            result = solution.MissingInteger(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
