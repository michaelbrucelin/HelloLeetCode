using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1296
{
    public class Test1296
    {
        public void Test()
        {
            Interface1296 solution = new Solution1296();
            int[] nums; int k;
            bool result, answer;
            int id = 0;

            // 1. 
            nums = [1, 2, 3, 3, 4, 4, 5, 6]; k = 4;
            answer = true;
            result = solution.IsPossibleDivide(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = [3, 2, 1, 2, 3, 4, 3, 4, 5, 9, 10, 11]; k = 3;
            answer = true;
            result = solution.IsPossibleDivide(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = [1, 2, 3, 4]; k = 3;
            answer = false;
            result = solution.IsPossibleDivide(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            nums = [15, 16, 17, 18, 19, 16, 17, 18, 19, 20, 6, 7, 8, 9, 10, 3, 4, 5, 6, 20]; k = 5;
            answer = false;
            result = solution.IsPossibleDivide(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            nums = [16, 21, 26, 35]; k = 4;
            answer = false;
            result = solution.IsPossibleDivide(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
