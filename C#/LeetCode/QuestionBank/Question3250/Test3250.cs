using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3250
{
    public class Test3250
    {
        public void Test()
        {
            Interface3250 solution = new Solution3250_7();
            int[] nums;
            int result, answer;
            int id = 0;

            // 1. 
            nums = [2, 3, 2];
            answer = 4;
            result = solution.CountOfPairs(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = [5, 5, 5, 5];
            answer = 126;
            result = solution.CountOfPairs(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = [40, 40, 40, 40, 41, 42, 43, 44, 45, 45];
            answer = 272278100;
            result = solution.CountOfPairs(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
