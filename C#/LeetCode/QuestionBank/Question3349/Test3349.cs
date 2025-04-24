using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3349
{
    public class Test3349
    {
        public void Test()
        {
            Interface3349 solution = new Solution3349();
            IList<int> nums; int k;
            bool result, answer;
            int id = 0;

            // 1. 
            nums = [2, 5, 7, 8, 9, 2, 3, 4, 3, 1]; k = 3;
            answer = true;
            result = solution.HasIncreasingSubarrays(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = [1, 2, 3, 4, 4, 4, 4, 5, 6, 7]; k = 5;
            answer = false;
            result = solution.HasIncreasingSubarrays(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
