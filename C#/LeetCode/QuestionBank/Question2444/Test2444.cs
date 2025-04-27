using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2444
{
    public class Test2444
    {
        public void Test()
        {
            Interface2444 solution = new Solution2444();
            int[] nums; int minK, maxK;
            long result, answer;
            int id = 0;

            // 1. 
            nums = [1, 3, 5, 2, 7, 5]; minK = 1; maxK = 5;
            answer = 2;
            result = solution.CountSubarrays(nums, minK, maxK);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = [1, 1, 1, 1]; minK = 1; maxK = 1;
            answer = 10;
            result = solution.CountSubarrays(nums, minK, maxK);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
