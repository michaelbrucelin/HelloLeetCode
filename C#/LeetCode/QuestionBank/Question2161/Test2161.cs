using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2161
{
    public class Test2161
    {
        public void Test()
        {
            Interface2161 solution = new Solution2161();
            int[] nums; int pivot;
            int[] result, answer;
            int id = 0;

            // 1. 
            nums = [9, 12, 5, 10, 14, 3, 10]; pivot = 10;
            answer = [9, 5, 3, 10, 10, 12, 14];
            result = solution.PivotArray(nums, pivot);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            nums = [-3, 4, 3, 2]; pivot = 2;
            answer = [-3, 2, 4, 3];
            result = solution.PivotArray(nums, pivot);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}
