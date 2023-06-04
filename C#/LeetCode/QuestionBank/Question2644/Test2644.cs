using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2644
{
    public class Test2644
    {
        public void Test()
        {
            Interface2644 solution = new Solution2644();
            int[] nums, divisors;
            int result, answer;
            int id = 0;

            // 1. 
            nums = new int[] { 4, 7, 9, 3, 9 }; divisors = new int[] { 5, 2, 3 };
            answer = 3;
            result = solution.MaxDivScore(nums, divisors);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = new int[] { 20, 14, 21, 10 }; divisors = new int[] { 5, 7, 5 };
            answer = 5;
            result = solution.MaxDivScore(nums, divisors);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = new int[] { 12 }; divisors = new int[] { 10, 16 };
            answer = 10;
            result = solution.MaxDivScore(nums, divisors);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
