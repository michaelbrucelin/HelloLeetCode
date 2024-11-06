using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3254
{
    public class Test3254
    {
        public void Test()
        {
            Interface3254 solution = new Solution3254();
            int[] nums; int k;
            int[] result, answer;
            int id = 0;

            // 1. 
            nums = [1, 2, 3, 4, 3, 2, 5]; k = 3;
            answer = [3, 4, -1, -1, -1];
            result = solution.ResultsArray(nums, k);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            nums = [2, 2, 2, 2, 2]; k = 4;
            answer = [-1, -1];
            result = solution.ResultsArray(nums, k);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            nums = [3, 2, 3, 2, 3, 2]; k = 2;
            answer = [-1, 3, -1, 3, -1];
            result = solution.ResultsArray(nums, k);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 4. 
            nums = [1, 3, 4]; k = 2;
            answer = [-1, 4];
            result = solution.ResultsArray(nums, k);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}
