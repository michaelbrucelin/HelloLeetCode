using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0421
{
    public class Test0421
    {
        public void Test()
        {
            Interface0421 solution = new Solution0421_2();
            int[] nums;
            int result, answer;
            int id = 0;

            // 1. 
            nums = new int[] { 3, 10, 5, 25, 2, 8 };
            answer = 28;
            result = solution.FindMaximumXOR(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = new int[] { 14, 70, 53, 83, 49, 91, 36, 80, 92, 51, 66, 70 };
            answer = 127;
            result = solution.FindMaximumXOR(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = new int[] { 4, 6, 7 };
            answer = 3;
            result = solution.FindMaximumXOR(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
