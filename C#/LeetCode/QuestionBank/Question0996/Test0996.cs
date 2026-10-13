using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0996
{
    public class Test0996
    {
        public void Test()
        {
            Interface0996 solution = new Solution0996();
            int[] nums;
            int result, answer;
            int id = 0;

            // 1. 
            nums = [1, 17, 8];
            answer = 2;
            result = solution.NumSquarefulPerms(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = [2, 2, 2];
            answer = 1;
            result = solution.NumSquarefulPerms(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = [2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2];
            answer = 1;
            result = solution.NumSquarefulPerms(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
