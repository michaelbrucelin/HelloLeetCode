using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview1617
{
    public class Test1617
    {
        public void Test()
        {
            Interface1617 solution = new Solution1617();
            int[] nums;
            int result, answer;
            int id = 0;

            // 1. 
            nums = new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 }; answer = 6;
            result = solution.MaxSubArray(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = new int[] { -1, -2, -3, -4, -5 }; answer = -1;
            result = solution.MaxSubArray(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = new int[] { -2, -1 }; answer = -1;
            result = solution.MaxSubArray(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            nums = new int[] { -1, 0 }; answer = 0;
            result = solution.MaxSubArray(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            nums = new int[] { 1, 2 }; answer = 3;
            result = solution.MaxSubArray(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
