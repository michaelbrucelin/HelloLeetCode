using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2411
{
    public class Test2411
    {
        public void Test()
        {
            Interface2411 solution = new Solution2411_2();
            int[] nums;
            int[] result, answer;
            int id = 0;

            // 1. 
            nums = [1, 0, 2, 1, 3];
            answer = [3, 3, 2, 2, 1];
            result = solution.SmallestSubarrays(nums);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            nums = [1, 2];
            answer = [2, 1];
            result = solution.SmallestSubarrays(nums);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            nums = [1, 0];
            answer = [1, 1];
            result = solution.SmallestSubarrays(nums);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}
