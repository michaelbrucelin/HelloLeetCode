using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0179
{
    public class Test0179
    {
        public void Test()
        {
            Interface0179 solution = new Solution0179();
            int[] nums;
            string result, answer;
            int id = 0;

            // 1. 
            nums = [10, 2];
            answer = "210";
            result = solution.LargestNumber(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = [3, 30, 34, 5, 9];
            answer = "9534330";
            result = solution.LargestNumber(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = [111311, 1113];
            answer = "1113111311";
            result = solution.LargestNumber(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            nums = [0, 0];
            answer = "0";
            result = solution.LargestNumber(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
