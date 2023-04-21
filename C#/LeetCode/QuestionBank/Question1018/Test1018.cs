using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1018
{
    public class Test1018
    {
        public void Test()
        {
            Interface1018 solution = new Solution1018_2();
            int[] nums;
            IList<bool> result, answer;
            int id = 0;

            // 1. 
            nums = new int[] { 0, 1, 1 };
            answer = new bool[] { true, false, false };
            result = solution.PrefixesDivBy5(nums);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 2. 
            nums = new int[] { 1, 1, 1 };
            answer = new bool[] { false, false, false };
            result = solution.PrefixesDivBy5(nums);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 3. 
            nums = new int[] { 0, 1, 1, 1, 1, 1 };
            answer = new bool[] { true, false, false, false, true, false };
            result = solution.PrefixesDivBy5(nums);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");
        }
    }
}
