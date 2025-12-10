using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1390
{
    public class Test1390
    {
        public void Test()
        {
            Interface1390 solution = new Solution1390();
            int[] nums;
            int result, answer;
            int id = 0;

            // 1. 
            nums = [21, 4, 7];
            answer = 32;
            result = solution.SumFourDivisors(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = [21, 21];
            answer = 64;
            result = solution.SumFourDivisors(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = [1, 2, 3, 4, 5];
            answer = 0;
            result = solution.SumFourDivisors(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
