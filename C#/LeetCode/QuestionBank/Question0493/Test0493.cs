using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0493
{
    public class Test0493
    {
        public void Test()
        {
            Interface0493 solution = new Solution0493();
            int[] nums;
            int result, answer;
            int id = 0;

            // 1. 
            nums = [1, 3, 2, 3, 1];
            answer = 2;
            result = solution.ReversePairs(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = [2, 4, 3, 5, 1];
            answer = 3;
            result = solution.ReversePairs(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = [2147483647, 2147483647, 2147483647, 2147483647, 2147483647, 2147483647];
            answer = 0;
            result = solution.ReversePairs(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
