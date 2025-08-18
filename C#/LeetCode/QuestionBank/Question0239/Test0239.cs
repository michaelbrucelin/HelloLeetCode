using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0239
{
    public class Test0239
    {
        public void Test()
        {
            Interface0239 solution = new Solution0239();
            int[] nums; int k;
            int[] result, answer;
            int id = 0;

            // 1. 
            nums = [1, 3, -1, -3, 5, 3, 6, 7];
            k = 3;
            answer = [3, 3, 5, 5, 6, 7];
            result = solution.MaxSlidingWindow(nums, k);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            nums = [1];
            k = 1;
            answer = [1];
            result = solution.MaxSlidingWindow(nums, k);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            nums = [9, 11];
            k = 2;
            answer = [11];
            result = solution.MaxSlidingWindow(nums, k);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}
