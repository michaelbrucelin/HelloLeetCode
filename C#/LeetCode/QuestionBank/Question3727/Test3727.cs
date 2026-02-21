using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3727
{
    public class Test3727
    {
        public void Test()
        {
            Interface3727 solution = new Solution3727_2();
            int[] nums;
            long result, answer;
            int id = 0;

            // 1. 
            nums = [1, 2, 3];
            answer = 12;
            result = solution.MaxAlternatingSum(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = [1, -1, 2, -2, 3, -3];
            answer = 16;
            result = solution.MaxAlternatingSum(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = [-6];
            answer = 36;
            result = solution.MaxAlternatingSum(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            nums = [19, -20];
            answer = 39;
            result = solution.MaxAlternatingSum(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            nums = [-7, 7, 1, -3];
            answer = 88;
            result = solution.MaxAlternatingSum(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
