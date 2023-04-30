using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2367
{
    public class Test2367
    {
        public void Test()
        {
            Interface2367 solution = new Solution2367_2();
            int[] nums; int diff;
            int result, answer;
            int id = 0;

            // 1. 
            nums = new int[] { 0, 1, 4, 6, 7, 10 }; diff = 3; answer = 2;
            result = solution.ArithmeticTriplets(nums, diff);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = new int[] { 4, 5, 6, 7, 8, 9 }; diff = 2; answer = 2;
            result = solution.ArithmeticTriplets(nums, diff);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = new int[] { 6, 14, 15, 26, 31, 36, 38, 41, 42, 45 }; diff = 5; answer = 2;
            result = solution.ArithmeticTriplets(nums, diff);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
