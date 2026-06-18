using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0330
{
    public class Test0330
    {
        public void Test()
        {
            Interface0330 solution = new Solution0330();
            int[] nums; int n;
            int result, answer;
            int id = 0;

            // 1. 
            nums = [1, 3]; n = 6;
            answer = 1;
            result = solution.MinPatches(nums, n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = [1, 5, 10]; n = 20;
            answer = 2;
            result = solution.MinPatches(nums, n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = [1, 2, 2]; n = 5;
            answer = 0;
            result = solution.MinPatches(nums, n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            nums = [1, 2, 31, 33]; n = 2147483647;
            answer = 28;
            result = solution.MinPatches(nums, n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
