using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1425
{
    public class Test1425
    {
        public void Test()
        {
            Interface1425 solution = new Solution1425();
            int[] nums; int k;
            int result, answer;
            int id = 0;

            // 1. 
            nums = [10, 2, -10, 5, 20]; k = 2;
            answer = 37;
            result = solution.ConstrainedSubsetSum(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = [-1, -2, -3]; k = 1;
            answer = -1;
            result = solution.ConstrainedSubsetSum(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = [10, -2, -10, -5, 20]; k = 2;
            answer = 23;
            result = solution.ConstrainedSubsetSum(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            nums = [-5266, 4019, 7336, -3681, -5767]; k = 2;
            answer = 11355;
            result = solution.ConstrainedSubsetSum(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
