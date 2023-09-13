using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2099
{
    public class Test2099
    {
        public void Test()
        {
            Interface2099 solution = new Solution2099_3();
            int[] nums; int k;
            int[] result, answer;
            int id = 0;

            // 1. 
            nums = new int[] { 2, 1, 3, 3 }; k = 2;
            answer = new int[] { 3, 3 };
            result = solution.MaxSubsequence(nums, k);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            nums = new int[] { -1, -2, 3, 4 }; k = 3;
            answer = new int[] { -1, 3, 4 };
            result = solution.MaxSubsequence(nums, k);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            nums = new int[] { 3, 4, 3, 3 }; k = 2;
            answer = new int[] { 3, 4 };
            result = solution.MaxSubsequence(nums, k);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}
