using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2770
{
    public class Test2770
    {
        public void Test()
        {
            Interface2770 solution = new Solution2770_2();
            int[] nums; int target;
            int result, answer;
            int id = 0;

            // 1. 
            nums = [1, 3, 6, 4, 1, 2]; target = 2;
            answer = 3;
            result = solution.MaximumJumps(nums, target);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = [1, 3, 6, 4, 1, 2]; target = 3;
            answer = 5;
            result = solution.MaximumJumps(nums, target);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = [1, 3, 6, 4, 1, 2]; target = 0;
            answer = -1;
            result = solution.MaximumJumps(nums, target);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            nums = [0, 2, 1, 3]; target = 1;
            answer = -1;
            result = solution.MaximumJumps(nums, target);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
