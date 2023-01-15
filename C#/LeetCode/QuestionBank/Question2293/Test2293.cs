using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2293
{
    public class Test2293
    {
        public void Test()
        {
            Interface2293 solution = new Solution2293();
            int[] nums;
            int result, answer;
            int id = 0;

            // 1. 
            nums = new int[] { 1, 3, 5, 2, 4, 8, 2, 2 };
            answer = 1; result = solution.MinMaxGame(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = new int[] { 3 };
            answer = 3; result = solution.MinMaxGame(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = new int[] { 70, 38, 21, 22 };
            answer = 22; result = solution.MinMaxGame(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
