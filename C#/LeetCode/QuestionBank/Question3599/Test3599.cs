using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3599
{
    public class Test3599
    {
        public void Test()
        {
            Interface3599 solution = new Solution3599();
            int[] nums; int k;
            int result, answer;
            int id = 0;

            // 1. 
            nums = [1, 2, 3]; k = 2;
            answer = 1;
            result = solution.MinXor(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = [2, 3, 3, 2]; k = 3;
            answer = 2;
            result = solution.MinXor(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = [1, 1, 2, 3, 1]; k = 2;
            answer = 0;
            result = solution.MinXor(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
