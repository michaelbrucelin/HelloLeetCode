using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1911
{
    public class Test1911
    {
        public void Test()
        {
            Interface1911 solution = new Solution1911();
            int[] nums;
            long result, answer;
            int id = 0;

            // 1. 
            nums = new int[] { 4, 2, 5, 3 };
            answer = 7;
            result = solution.MaxAlternatingSum(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = new int[] { 5, 6, 7, 8 };
            answer = 8;
            result = solution.MaxAlternatingSum(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = new int[] { 6, 2, 1, 2, 4, 5 };
            answer = 10;
            result = solution.MaxAlternatingSum(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
