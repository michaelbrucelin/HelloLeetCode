using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2009
{
    public class Test2009
    {
        public void Test()
        {
            Interface2009 solution = new Solution2009();
            int[] nums;
            int result, answer;
            int id = 0;

            // 1. 
            nums = [4, 2, 5, 3];
            answer = 0;
            result = solution.MinOperations(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = [1, 2, 3, 5, 6];
            answer = 1;
            result = solution.MinOperations(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = [1, 10, 100, 1000];
            answer = 3;
            result = solution.MinOperations(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
