using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2460
{
    public class Test2460
    {
        public void Test()
        {
            Interface2460 solution = new Solution2460();
            int[] nums;
            int[] result, answer;
            int id = 0;

            // 1. 
            nums = new int[] { 1, 2, 2, 1, 1, 0 };
            answer = new int[] { 1, 4, 2, 0, 0, 0 };
            result = solution.ApplyOperations(nums);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            nums = new int[] { 0, 1 };
            answer = new int[] { 1, 0 };
            result = solution.ApplyOperations(nums);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            nums = new int[] { 847, 847, 0, 0, 0, 399, 416, 416, 879, 879, 206, 206, 206, 272 };
            answer = new int[] { 1694, 399, 832, 1758, 412, 206, 272, 0, 0, 0, 0, 0, 0, 0 };
            result = solution.ApplyOperations(nums);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}
