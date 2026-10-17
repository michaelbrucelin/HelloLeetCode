using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3551
{
    public class Test3551
    {
        public void Test()
        {
            Interface3551 solution = new Solution3551();
            int[] nums;
            int result, answer;
            int id = 0;

            // 1. 
            nums = [37, 100];
            answer = 1;
            result = solution.MinSwaps(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = [22, 14, 33, 7];
            answer = 0;
            result = solution.MinSwaps(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = [18, 43, 34, 16];
            answer = 2;
            result = solution.MinSwaps(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            nums = [625468152, 191921893, 821181574];
            answer = 2;
            result = solution.MinSwaps(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
