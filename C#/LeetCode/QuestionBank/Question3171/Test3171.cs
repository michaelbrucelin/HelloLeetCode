using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3171
{
    public class Test3171
    {
        public void Test()
        {
            Interface3171 solution = new Solution3171_3();
            int[] nums; int k;
            int result, answer;
            int id = 0;

            // 1. 
            nums = [1, 2, 4, 5]; k = 3;
            answer = 0;
            result = solution.MinimumDifference(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = [1, 3, 1, 3]; k = 2;
            answer = 1;
            result = solution.MinimumDifference(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = [1]; k = 10;
            answer = 9;
            result = solution.MinimumDifference(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            nums = [6, 9, 10]; k = 7;
            answer = 1;
            result = solution.MinimumDifference(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
