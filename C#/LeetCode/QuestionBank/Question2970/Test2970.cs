using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2970
{
    public class Test2970
    {
        public void Test()
        {
            Interface2970 solution = new Solution2970();
            int[] nums;
            int result, answer;
            int id = 0;

            // 1. 
            nums = new int[] { 1, 2, 3, 4 };
            answer = 10;
            result = solution.IncremovableSubarrayCount(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = new int[] { 6, 5, 7, 8 };
            answer = 7;
            result = solution.IncremovableSubarrayCount(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = new int[] { 8, 7, 6, 6 };
            answer = 3;
            result = solution.IncremovableSubarrayCount(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
