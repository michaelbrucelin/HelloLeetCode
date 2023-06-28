using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1681
{
    public class Test1681
    {
        public void Test()
        {
            Interface1681 solution = new Solution1681();
            int[] nums; int k;
            int result, answer;
            int id = 0;

            // 1. 
            nums = new int[] { 1, 2, 1, 4 }; k = 2;
            answer = 4;
            result = solution.MinimumIncompatibility(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = new int[] { 6, 3, 8, 1, 3, 1, 2, 2 }; k = 4;
            answer = 6;
            result = solution.MinimumIncompatibility(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = new int[] { 5, 3, 3, 6, 3, 3 }; k = 3;
            answer = -1;
            result = solution.MinimumIncompatibility(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
