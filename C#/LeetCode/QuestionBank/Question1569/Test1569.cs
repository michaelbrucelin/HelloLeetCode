using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1569
{
    public class Test1569
    {
        public void Test()
        {
            Interface1569 solution = new Solution1569_err();
            int[] nums;
            int result, answer;
            int id = 0;

            // 1. 
            nums = [2, 1, 3];
            answer = 1;
            result = solution.NumOfWays(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = [3, 4, 5, 1, 2];
            answer = 5;
            result = solution.NumOfWays(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = [1, 2, 3];
            answer = 0;
            result = solution.NumOfWays(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            nums = [3, 1, 2, 5, 4, 6];
            answer = 19;
            result = solution.NumOfWays(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
