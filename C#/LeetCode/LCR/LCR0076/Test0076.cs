using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0076
{
    public class Test0076
    {
        public void Test()
        {
            Interface0076 solution = new Solution0076_2();
            int[] nums; int k;
            int result, answer;
            int id = 0;

            // 1. 
            nums = [3, 2, 1, 5, 6, 4]; k = 2;
            answer = 5;
            result = solution.FindKthLargest(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = [3, 2, 3, 1, 2, 4, 5, 5, 6]; k = 4;
            answer = 4;
            result = solution.FindKthLargest(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = [2, 1]; k = 1;
            answer = 2;
            result = solution.FindKthLargest(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
