using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1658
{
    public class Test1658
    {
        public void Test()
        {
            Interface1658 solution = new Solution1658_2_2();
            int[] nums; int x;
            int result, answer;
            int id = 0;

            // 1. 
            nums = new int[] { 1, 1, 4, 2, 3 }; x = 5; answer = 2;
            result = solution.MinOperations(nums, x);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = new int[] { 5, 6, 7, 8, 9 }; x = 4; answer = -1;
            result = solution.MinOperations(nums, x);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = new int[] { 3, 2, 20, 1, 1, 3 }; x = 10; answer = 5;
            result = solution.MinOperations(nums, x);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            nums = new int[] { 1, 1 }; x = 3; answer = -1;
            result = solution.MinOperations(nums, x);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            nums = new int[] { 5, 2, 3, 1, 1 }; x = 5; answer = 1;
            result = solution.MinOperations(nums, x);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
