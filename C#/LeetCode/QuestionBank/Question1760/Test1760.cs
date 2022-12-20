using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1760
{
    public class Test1760
    {
        public void Test()
        {
            Interface1760 solution = new Solution1760();
            int[] nums; int maxOperations;
            int result, answer;
            int id = 0;

            // 1.
            nums = new int[] { 9 }; maxOperations = 2;
            answer = 3; result = solution.MinimumSize(nums, maxOperations);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2.
            nums = new int[] { 2, 4, 8, 2 }; maxOperations = 4;
            answer = 2; result = solution.MinimumSize(nums, maxOperations);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3.
            nums = new int[] { 7, 17 }; maxOperations = 2;
            answer = 7; result = solution.MinimumSize(nums, maxOperations);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4.
            nums = new int[] { 7, 17 }; maxOperations = 3;
            answer = 6; result = solution.MinimumSize(nums, maxOperations);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
