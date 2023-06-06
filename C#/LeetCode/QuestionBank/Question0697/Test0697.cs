using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0697
{
    public class Test0697
    {
        public void Test()
        {
            Interface0697 solution = new Solution0697();
            int[] nums;
            int result, answer;
            int id = 0;

            // 1. 
            nums = new int[] { 1, 2, 2, 3, 1 };
            answer = 2;
            result = solution.FindShortestSubArray(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = new int[] { 1, 2, 2, 3, 1, 4, 2 };
            answer = 6;
            result = solution.FindShortestSubArray(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
