using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3819
{
    public class Test3819
    {
        public void Test()
        {
            Interface3819 solution = new Solution3819();
            int[] nums; int k;
            int[] result, answer;
            int id = 0;

            // 1. 
            nums = [1, -2, 3, -4]; k = 3;
            answer = [3, -2, 1, -4];
            result = solution.RotateElements(nums, k);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            nums = [-3, -2, 7]; k = 1;
            answer = [-3, -2, 7];
            result = solution.RotateElements(nums, k);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            nums = [5, 4, -9, 6]; k = 2;
            answer = [6, 5, -9, 4];
            result = solution.RotateElements(nums, k);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 4. 
            nums = [-14, 2, 2]; k = 98321;
            answer = [-14, 2, 2];
            result = solution.RotateElements(nums, k);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}
