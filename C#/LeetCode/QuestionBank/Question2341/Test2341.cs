using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2341
{
    public class Test2341
    {
        public void Test()
        {
            Interface2341 solution = new Solution2341_2();
            int[] nums;
            int[] result, answer;
            int id = 0;

            // 1. 
            nums = new int[] { 1, 3, 2, 1, 3, 2, 2 }; answer = new int[] { 3, 1 };
            result = solution.NumberOfPairs(nums);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 2. 
            nums = new int[] { 1, 1 }; answer = new int[] { 1, 0 };
            result = solution.NumberOfPairs(nums);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 3. 
            nums = new int[] { 0 }; answer = new int[] { 0, 1 };
            result = solution.NumberOfPairs(nums);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");
        }
    }
}
