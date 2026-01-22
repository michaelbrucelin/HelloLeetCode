using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3507
{
    public class Test3507
    {
        public void Test()
        {
            Interface3507 solution = new Solution3507();
            int[] nums;
            int result, answer;
            int id = 0;

            // 1. 
            nums = [5, 2, 3, 1];
            answer = 2;
            result = solution.MinimumPairRemoval(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = [1, 2, 2];
            answer = 0;
            result = solution.MinimumPairRemoval(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
