using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2221
{
    public class Test2221
    {
        public void Test()
        {
            Interface2221 solution = new Solution2221_3();
            int[] nums;
            int result, answer;
            int id = 0;

            // 1. 
            nums = [1, 2, 3, 4, 5];
            answer = 8;
            result = solution.TriangularSum(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = [5];
            answer = 5;
            result = solution.TriangularSum(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = new int[1000];
            answer = 0;
            result = solution.TriangularSum(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
