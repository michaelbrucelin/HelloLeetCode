using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2972
{
    public class Test2972
    {
        public void Test()
        {
            Interface2972 solution = new Solution2972_2();
            int[] nums;
            long result, answer;
            int id = 0;

            // 1. 
            nums = [1, 2, 3, 4];
            answer = 10;
            result = solution.IncremovableSubarrayCount(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = [6, 5, 7, 8];
            answer = 7;
            result = solution.IncremovableSubarrayCount(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = [8, 7, 6, 6];
            answer = 3;
            result = solution.IncremovableSubarrayCount(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            nums = [1, 2, 3, 4, 5, 1, 11, 12, 13, 14, 15];
            answer = 37;
            result = solution.IncremovableSubarrayCount(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
