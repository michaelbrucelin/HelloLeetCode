using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1749
{
    public class Test1749
    {
        public void Test()
        {
            Interface1749 solution = new Solution1749();
            int[] nums;
            int result, answer;
            int id = 0;

            // 1. 
            nums = new int[] { 1, -3, 2, 3, -4 };
            answer = 5;
            result = solution.MaxAbsoluteSum(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = new int[] { 2, -5, 1, -4, 3, -2 };
            answer = 8;
            result = solution.MaxAbsoluteSum(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
