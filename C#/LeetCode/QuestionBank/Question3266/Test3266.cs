using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3266
{
    public class Test3266
    {
        public void Test()
        {
            Interface3266 solution = new Solution3266();
            int[] nums; int k, multiplier;
            int[] result, answer;
            int id = 0;

            // 1. 
            nums = [2, 1, 3, 5, 6]; k = 5; multiplier = 2;
            answer = [8, 4, 6, 5, 6];
            result = solution.GetFinalState(nums, k, multiplier);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            nums = [100000, 2000]; k = 2; multiplier = 1000000;
            answer = [999999307, 999999993];
            result = solution.GetFinalState(nums, k, multiplier);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            nums = [66307295, 441787703, 589039035, 322281864]; k = 900900704; multiplier = 641725;
            answer = [664480092, 763599523, 886046925, 47878852];
            result = solution.GetFinalState(nums, k, multiplier);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}
