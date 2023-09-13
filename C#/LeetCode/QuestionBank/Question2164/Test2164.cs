using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2164
{
    public class Test2164
    {
        public void Test()
        {
            Interface2164 solution = new Solution2164();
            int[] nums;
            int[] result, answer;
            int id = 0;

            // 1. 
            nums = new int[] { 4, 1, 2, 3 };
            answer = new int[] { 2, 3, 4, 1 };
            result = solution.SortEvenOdd(nums);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            nums = new int[] { 2, 1 };
            answer = new int[] { 2, 1 };
            result = solution.SortEvenOdd(nums);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}
