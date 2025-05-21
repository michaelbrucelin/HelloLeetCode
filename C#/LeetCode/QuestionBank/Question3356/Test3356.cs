using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3356
{
    public class Test3356
    {
        public void Test()
        {
            Interface3356 solution = new Solution3356();
            int[] nums; int[][] queries;
            int result, answer;
            int id = 0;

            // 1. 
            nums = [2, 0, 2]; queries = [[0, 2, 1], [0, 2, 1], [1, 1, 3]];
            answer = 2;
            result = solution.MinZeroArray(nums, queries);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = [4, 3, 2, 1]; queries = [[1, 3, 2], [0, 2, 1]];
            answer = -1;
            result = solution.MinZeroArray(nums, queries);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = [0]; queries = [[0, 0, 2], [0, 0, 4], [0, 0, 4], [0, 0, 3], [0, 0, 5]];
            answer = 0;
            result = solution.MinZeroArray(nums, queries);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
