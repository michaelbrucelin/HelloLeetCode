using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2873
{
    public class Test2873
    {
        public void Test()
        {
            Interface2873 solution = new Solution2873_3();
            int[] nums;
            long result, answer;
            int id = 0;

            // 1. 
            nums = new int[] { 12, 6, 1, 2, 7 };
            answer = 77;
            result = solution.MaximumTripletValue(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = new int[] { 1, 10, 3, 4, 19 };
            answer = 133;
            result = solution.MaximumTripletValue(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = new int[] { 1, 2, 3 };
            answer = 0;
            result = solution.MaximumTripletValue(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4.
            nums = new int[] { 1000000, 1, 1000000 };
            answer = 999999000000;
            result = solution.MaximumTripletValue(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
