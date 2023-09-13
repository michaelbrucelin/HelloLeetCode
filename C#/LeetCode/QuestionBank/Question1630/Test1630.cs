using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1630
{
    public class Test1630
    {
        public void Test()
        {
            Interface1630 solution = new Solution1630_3();
            int[] nums; int[] l, r;
            IList<bool> result, answer;
            int id = 0;

            // 1. 
            nums = new int[] { 4, 6, 5, 9, 3, 7 }; l = new int[] { 0, 0, 2 }; r = new int[] { 2, 3, 5 };
            answer = new bool[] { true, false, true };
            result = solution.CheckArithmeticSubarrays(nums, l, r);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            nums = new int[] { -12, -9, -3, -12, -6, 15, 20, -25, -20, -15, -10 };
            l = new int[] { 0, 1, 6, 4, 8, 7 }; r = new int[] { 4, 4, 9, 7, 9, 10 };
            answer = new bool[] { false, true, false, false, true, true };
            result = solution.CheckArithmeticSubarrays(nums, l, r);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}
