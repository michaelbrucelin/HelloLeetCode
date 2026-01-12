using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1887
{
    public class Test1887
    {
        public void Test()
        {
            Interface1887 solution = new Solution1887();
            int[] nums;
            int result, answer;
            int id = 0;

            // 1. 
            nums = [5, 1, 3];
            answer = 3;
            result = solution.ReductionOperations(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = [1, 1, 1];
            answer = 0;
            result = solution.ReductionOperations(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = [1, 1, 2, 2, 3];
            answer = 4;
            result = solution.ReductionOperations(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
