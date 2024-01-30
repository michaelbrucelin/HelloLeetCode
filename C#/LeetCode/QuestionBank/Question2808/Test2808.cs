using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2808
{
    public class Test2808
    {
        public void Test()
        {
            Interface2808 solution = new Solution2808_api();
            IList<int> nums;
            int result, answer;
            int id = 0;

            // 1. 
            nums = new int[] { 1, 2, 1, 2 };
            answer = 1;
            result = solution.MinimumSeconds(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = new int[] { 2, 1, 3, 3, 2 };
            answer = 2;
            result = solution.MinimumSeconds(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = new int[] { 5, 5, 5, 5 };
            answer = 0;
            result = solution.MinimumSeconds(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
