using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2576
{
    public class Test2576
    {
        public void Test()
        {
            Interface2576 solution = new Solution2576_err();
            int[] nums;
            int result, answer;
            int id = 0;

            // 1. 
            nums = [3, 5, 2, 4];
            answer = 2;
            result = solution.MaxNumOfMarkedIndices(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = [9, 2, 5, 4];
            answer = 4;
            result = solution.MaxNumOfMarkedIndices(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = [7, 6, 8];
            answer = 0;
            result = solution.MaxNumOfMarkedIndices(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
