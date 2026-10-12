using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2572
{
    public class Test2572
    {
        public void Test()
        {
            Interface2572 solution = new Solution2572();
            int[] nums;
            int result, answer;
            int id = 0;

            // 1. 
            nums = [3, 4, 4, 5];
            answer = 3;
            result = solution.SquareFreeSubsets(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = [1];
            answer = 1;
            result = solution.SquareFreeSubsets(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = [8, 11, 17, 2, 25, 29, 21, 20, 4, 22];
            answer = 39;
            result = solution.SquareFreeSubsets(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            nums = [17, 27, 20, 1, 19];
            answer = 7;
            result = solution.SquareFreeSubsets(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
