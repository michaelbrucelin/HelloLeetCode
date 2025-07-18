using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2163
{
    public class Test2163
    {
        public void Test()
        {
            Interface2163 solution = new Solution2163();
            int[] nums;
            long result, answer;
            int id = 0;

            // 1. 
            nums = [3, 1, 2];
            answer = -1;
            result = solution.MinimumDifference(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = [7, 9, 5, 8, 1, 3];
            answer = 1;
            result = solution.MinimumDifference(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
