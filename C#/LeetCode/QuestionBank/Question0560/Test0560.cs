using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0560
{
    public class Test0560
    {
        public void Test()
        {
            Interface0560 solution = new Solution0560();
            int[] nums; int k;
            int result, answer;
            int id = 0;

            // 1. 
            nums = [1, 1, 1]; k = 2;
            answer = 2;
            result = solution.SubarraySum(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = [1, 2, 3]; k = 3;
            answer = 2;
            result = solution.SubarraySum(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
