using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2597
{
    public class Test2597
    {
        public void Test()
        {
            Interface2597 solution = new Solution2597();
            int[] nums; int k;
            int result, answer;
            int id = 0;

            // 1. 
            nums = [2, 4, 6]; k = 2;
            answer = 4;
            result = solution.BeautifulSubsets(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = [1]; k = 1;
            answer = 1;
            result = solution.BeautifulSubsets(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = [2, 4, 6, 6]; k = 2;
            answer = 8;
            result = solution.BeautifulSubsets(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            nums = [1, 1, 2, 3]; k = 1;
            answer = 8;
            result = solution.BeautifulSubsets(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
