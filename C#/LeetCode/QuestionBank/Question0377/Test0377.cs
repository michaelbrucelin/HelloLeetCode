using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0377
{
    public class Test0377
    {
        public void Test()
        {
            Interface0377 solution = new Solution0377();
            int[] nums; int target;
            int result, answer;
            int id = 0;

            // 1. 
            nums = [1, 2, 3]; target = 4;
            answer = 7;
            result = solution.CombinationSum4(nums, target);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = [9]; target = 3;
            answer = 0;
            result = solution.CombinationSum4(nums, target);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = [2, 1, 3]; target = 35;
            answer = 1132436852;
            result = solution.CombinationSum4(nums, target);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
