using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3038
{
    public class Test3038
    {
        public void Test()
        {
            Interface3038 solution = new Solution3038();
            int[] nums;
            int result, answer;
            int id = 0;

            // 1. 
            nums = new int[] { 3, 2, 1, 4, 5 };
            answer = 2;
            result = solution.MaxOperations(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = new int[] { 3, 2, 6, 1, 4 };
            answer = 1;
            result = solution.MaxOperations(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = new int[] { 2, 2, 3, 2, 4, 2, 3, 3, 1, 3 };
            answer = 1;
            result = solution.MaxOperations(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
