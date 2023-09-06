using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0673
{
    public class Test0673
    {
        public void Test()
        {
            Interface0673 solution = new Solution0673();
            int[] nums;
            int result, answer;
            int id = 0;

            // 1. 
            nums = new int[] { 1, 3, 5, 4, 7 };
            answer = 2;
            result = solution.FindNumberOfLIS(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = new int[] { 2, 2, 2, 2, 2 };
            answer = 5;
            result = solution.FindNumberOfLIS(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
