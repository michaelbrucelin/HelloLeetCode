using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3640
{
    public class Test3640
    {
        public void Test()
        {
            Interface3640 solution = new Solution3640();
            int[] nums;
            long result, answer;
            int id = 0;

            // 1. 
            nums = [0, -2, -1, -3, 0, 2, -1];
            answer = -4;
            result = solution.MaxSumTrionic(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = [1, 4, 2, 7];
            answer = 14;
            result = solution.MaxSumTrionic(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = [-999999985, -999999930, -999999992, -999999927];
            answer = -3999999834;
            result = solution.MaxSumTrionic(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
