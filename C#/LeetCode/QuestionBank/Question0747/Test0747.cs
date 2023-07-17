using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0747
{
    public class Test0747
    {
        public void Test()
        {
            Interface0747 solution = new Solution0747();
            int[] nums;
            int result, answer;
            int id = 0;

            // 1. 
            nums = new int[] { 3, 6, 1, 0 };
            answer = 1;
            result = solution.DominantIndex(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = new int[] { 1, 2, 3, 4 };
            answer = -1;
            result = solution.DominantIndex(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = new int[] { 0 };
            answer = 0;
            result = solution.DominantIndex(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
