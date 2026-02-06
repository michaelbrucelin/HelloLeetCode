using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3634
{
    public class Test3634
    {
        public void Test()
        {
            Interface3634 solution = new Solution3634();
            int[] nums; int k;
            int result, answer;
            int id = 0;

            // 1. 
            nums = [2, 1, 5]; k = 2;
            answer = 1;
            result = solution.MinRemoval(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = [1, 6, 2, 9]; k = 3;
            answer = 2;
            result = solution.MinRemoval(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = [4, 6]; k = 2;
            answer = 0;
            result = solution.MinRemoval(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            nums = [466, 306, 76, 17, 60, 246, 341, 284]; k = 2;
            answer = 3;
            result = solution.MinRemoval(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
