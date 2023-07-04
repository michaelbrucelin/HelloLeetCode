using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1389
{
    public class Test1389
    {
        public void Test()
        {
            Interface1389 solution = new Solution1389_2();
            int[] nums, index;
            int[] result, answer;
            int id = 0;

            // 1. 
            nums = new int[] { 0, 1, 2, 3, 4 }; index = new int[] { 0, 1, 2, 2, 1 };
            answer = new int[] { 0, 4, 1, 3, 2 };
            result = solution.CreateTargetArray(nums, index);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 2. 
            nums = new int[] { 1, 2, 3, 4, 0 }; index = new int[] { 0, 1, 2, 3, 0 };
            answer = new int[] { 0, 1, 2, 3, 4 };
            result = solution.CreateTargetArray(nums, index);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 3. 
            nums = new int[] { 1 }; index = new int[] { 0 };
            answer = new int[] { 1 };
            result = solution.CreateTargetArray(nums, index);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");
        }
    }
}
