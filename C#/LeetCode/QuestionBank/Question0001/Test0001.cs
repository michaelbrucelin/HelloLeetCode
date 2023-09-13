using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0001
{
    public class Test0001
    {
        public void Test()
        {
            Interface0001 solution = new Solution0001_api();
            int[] nums; int target;
            int[] result, answer;
            int id = 0;

            // 1. 
            nums = new int[] { 2, 7, 11, 15 }; target = 9;
            answer = new int[] { 0, 1 };
            result = solution.TwoSum(nums, target);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            nums = new int[] { 3, 2, 4 }; target = 6;
            answer = new int[] { 1, 2 };
            result = solution.TwoSum(nums, target);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            nums = new int[] { 3, 3 }; target = 6;
            answer = new int[] { 0, 1 };
            result = solution.TwoSum(nums, target);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}
