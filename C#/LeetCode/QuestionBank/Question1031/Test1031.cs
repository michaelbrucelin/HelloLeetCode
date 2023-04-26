using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1031
{
    public class Test1031
    {
        public void Test()
        {
            Interface1031 solution = new Solution1031();
            int[] nums; int firstLen, secondLen;
            int result, answer;
            int id = 0;

            // 1. 
            nums = new int[] { 0, 6, 5, 2, 2, 5, 1, 9, 4 }; firstLen = 1; secondLen = 2;
            answer = 20;
            result = solution.MaxSumTwoNoOverlap(nums, firstLen, secondLen);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = new int[] { 3, 8, 1, 3, 2, 1, 8, 9, 0 }; firstLen = 3; secondLen = 2;
            answer = 29;
            result = solution.MaxSumTwoNoOverlap(nums, firstLen, secondLen);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = new int[] { 2, 1, 5, 6, 0, 9, 5, 0, 3, 8 }; firstLen = 4; secondLen = 3;
            answer = 31;
            result = solution.MaxSumTwoNoOverlap(nums, firstLen, secondLen);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
