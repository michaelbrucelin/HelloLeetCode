using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1913
{
    public class Test1913
    {
        public void Test()
        {
            Interface1913 solution = new Solution1913();
            int[] nums;
            int result, answer;
            int id = 0;

            // 1. 
            nums = new int[] { 5, 6, 2, 7, 4 };
            answer = 34;
            result = solution.MaxProductDifference(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = new int[] { 4, 2, 5, 9, 7, 4, 8 };
            answer = 64;
            result = solution.MaxProductDifference(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = new int[] { 1, 6, 7, 5, 2, 4, 10, 6, 4 };
            answer = 68;
            result = solution.MaxProductDifference(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
