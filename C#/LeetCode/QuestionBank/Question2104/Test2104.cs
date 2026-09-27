using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2104
{
    public class Test2104
    {
        public void Test()
        {
            Interface2104 solution = new Solution2104();
            int[] nums;
            long result, answer;
            int id = 0;

            // 1. 
            nums = [1, 2, 3];
            answer = 4;
            result = solution.SubArrayRanges(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = [1, 3, 3];
            answer = 4;
            result = solution.SubArrayRanges(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = [4, -2, -3, 4, 1];
            answer = 59;
            result = solution.SubArrayRanges(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
