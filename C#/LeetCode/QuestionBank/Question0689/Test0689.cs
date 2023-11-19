using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0689
{
    public class Test0689
    {
        public void Test()
        {
            Interface0689 solution = new Solution0689();
            int[] nums; int k;
            int[] result, answer;
            int id = 0;

            // 1. 
            nums = [1, 2, 1, 2, 6, 7, 5, 1]; k = 2;
            answer = [0, 3, 5];
            result = solution.MaxSumOfThreeSubarrays(nums, k);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            nums = [1, 2, 1, 2, 1, 2, 1, 2, 1]; k = 2;
            answer = [0, 2, 4];
            result = solution.MaxSumOfThreeSubarrays(nums, k);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            nums = [7, 13, 20, 19, 19, 2, 10, 1, 1, 19]; k = 3;
            answer = [1, 4, 7];
            result = solution.MaxSumOfThreeSubarrays(nums, k);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 4. 
            nums = [17, 9, 3, 2, 7, 10, 20, 1, 13, 4, 5, 16, 4, 1, 17, 6, 4, 19, 8, 3]; k = 4;
            answer = [3, 8, 14];
            result = solution.MaxSumOfThreeSubarrays(nums, k);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}
