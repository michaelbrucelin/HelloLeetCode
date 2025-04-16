using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2537
{
    public class Test2537
    {
        public void Test()
        {
            Interface2537 solution = new Solution2537();
            int[] nums; int k;
            long result, answer;
            int id = 0;

            // 1. 
            nums = [1, 1, 1, 1, 1]; k = 10;
            answer = 1;
            result = solution.CountGood(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = [3, 1, 4, 3, 2, 2, 4]; k = 2;
            answer = 4;
            result = solution.CountGood(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
