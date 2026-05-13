using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1674
{
    public class Test1674
    {
        public void Test()
        {
            Interface1674 solution = new Solution1674_err();
            int[] nums; int limit;
            int result, answer;
            int id = 0;

            // 1. 
            nums = [1, 2, 4, 3]; limit = 4;
            answer = 1;
            result = solution.MinMoves(nums, limit);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = [1, 2, 2, 1]; limit = 2;
            answer = 2;
            result = solution.MinMoves(nums, limit);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = [1, 2, 1, 2]; limit = 2;
            answer = 0;
            result = solution.MinMoves(nums, limit);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            nums = [20744, 7642, 19090, 9992, 2457, 16848, 3458, 15721]; limit = 22891;
            answer = 4;
            result = solution.MinMoves(nums, limit);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
