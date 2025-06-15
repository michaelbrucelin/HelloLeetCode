using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2616
{
    public class Test2616
    {
        public void Test()
        {
            Interface2616 solution = new Solution2616_err();
            int[] nums; int p;
            int result, answer;
            int id = 0;

            // 1. 
            nums = [10, 1, 2, 7, 1, 3]; p = 2;
            answer = 1;
            result = solution.MinimizeMax(nums, p);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = [4, 2, 1, 2]; p = 1;
            answer = 0;
            result = solution.MinimizeMax(nums, p);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = [3, 3, 5, 1, 0, 5, 6, 6]; p = 4;
            answer = 1;
            result = solution.MinimizeMax(nums, p);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            nums = [3, 4, 2, 3, 2, 1, 2]; p = 3;
            answer = 1;
            result = solution.MinimizeMax(nums, p);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
