using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3691
{
    public class Test3691
    {
        public void Test()
        {
            Interface3691 solution = new Solution3691_err();
            int[] nums; int k;
            long result, answer;
            int id = 0;

            // 1. 
            nums = [1, 3, 2]; k = 2;
            answer = 4;
            result = solution.MaxTotalValue(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = [4, 2, 5, 1]; k = 3;
            answer = 12;
            result = solution.MaxTotalValue(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = [11, 8]; k = 2;
            answer = 3;
            result = solution.MaxTotalValue(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            nums = [11, 8]; k = 3;
            answer = 3;
            result = solution.MaxTotalValue(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            nums = [9, 9, 37]; k = 2;
            answer = 56;
            result = solution.MaxTotalValue(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 6. 
            nums = [20, 21, 46]; k = 3;
            answer = 52;
            result = solution.MaxTotalValue(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
