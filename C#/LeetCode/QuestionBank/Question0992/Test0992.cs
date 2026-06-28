using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0992
{
    public class Test0992
    {
        public void Test()
        {
            Interface0992 solution = new Solution0992();
            int[] nums; int k;
            int result, answer;
            int id = 0;

            // 1. 
            nums = [1, 2, 1, 2, 3]; k = 2;
            answer = 7;
            result = solution.SubarraysWithKDistinct(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = [1, 2, 1, 3, 4]; k = 3;
            answer = 3;
            result = solution.SubarraysWithKDistinct(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = [2, 1, 1, 1, 2]; k = 1;
            answer = 8;
            result = solution.SubarraysWithKDistinct(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
