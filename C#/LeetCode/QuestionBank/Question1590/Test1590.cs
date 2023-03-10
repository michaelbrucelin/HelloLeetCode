using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1590
{
    public class Test1590
    {
        public void Test()
        {
            Interface1590 solution = new Solution1590();
            int[] nums; int p;
            int result, answer;
            int id = 0;

            // 1. 
            nums = new int[] { 3, 1, 4, 2 }; p = 6; answer = 1;
            result = solution.MinSubarray(nums, p);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = new int[] { 6, 3, 5, 2 }; p = 9; answer = 2;
            result = solution.MinSubarray(nums, p);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = new int[] { 1, 2, 3 }; p = 3; answer = 0;
            result = solution.MinSubarray(nums, p);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            nums = new int[] { 1, 2, 3 }; p = 7; answer = -1;
            result = solution.MinSubarray(nums, p);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            nums = new int[] { 1000000000, 1000000000, 1000000000 }; p = 3; answer = 0;
            result = solution.MinSubarray(nums, p);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
