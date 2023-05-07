using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1995
{
    public class Test1995
    {
        public void Test()
        {
            Interface1995 solution = new Solution1995_err2();
            int[] nums;
            int result, answer;
            int id = 0;

            // 1. 
            nums = new int[] { 1, 2, 3, 6 }; result = 1;
            answer = solution.CountQuadruplets(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = new int[] { 3, 3, 6, 4, 5 }; result = 0;
            answer = solution.CountQuadruplets(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = new int[] { 1, 1, 1, 3, 5 }; result = 4;
            answer = solution.CountQuadruplets(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            nums = new int[] { 28, 8, 49, 85, 37, 90, 20, 8 }; result = 1;
            answer = solution.CountQuadruplets(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            nums = new int[] { 1, 1, 1, 1, 1, 1, 3, 3, 3, 3, 5 }; result = 140;
            answer = solution.CountQuadruplets(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
