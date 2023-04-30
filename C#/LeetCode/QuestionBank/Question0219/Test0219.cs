using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0219
{
    public class Test0219
    {
        public void Test()
        {
            Interface0219 solution = new Solution0219_5();
            int[] nums; int k;
            bool result, answer;
            int id = 0;

            // 1. 
            nums = new int[] { 1, 2, 3, 1 }; k = 3; answer = true;
            result = solution.ContainsNearbyDuplicate(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = new int[] { 1, 0, 1, 1 }; k = 1; answer = true;
            result = solution.ContainsNearbyDuplicate(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = new int[] { 1, 2, 3, 1, 2, 3 }; k = 2; answer = false;
            result = solution.ContainsNearbyDuplicate(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
