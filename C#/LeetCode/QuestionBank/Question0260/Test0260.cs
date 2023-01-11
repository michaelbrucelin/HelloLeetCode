using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0260
{
    public class Test0260
    {
        public void Test()
        {
            Interface0260 solution = new Solution0260();
            int[] nums;
            int[] result, answer;
            int id = 0;

            // 1. 
            nums = new int[] { 1, 2, 1, 3, 2, 5 };
            answer = new int[] { 3, 5 };
            result = solution.SingleNumber(nums); Array.Sort(result);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 2. 
            nums = new int[] { -1, 0 };
            answer = new int[] { -1, 0 };
            result = solution.SingleNumber(nums); Array.Sort(result);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 3. 
            nums = new int[] { 0, 1 };
            answer = new int[] { 0, 1 };
            result = solution.SingleNumber(nums); Array.Sort(result);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 4. 
            nums = new int[] { 1, -1, 2, 2, -2, -2 };
            answer = new int[] { -1, 1 };
            result = solution.SingleNumber(nums); Array.Sort(result);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 5. 
            nums = new int[] { -1638685546, -2084083624, -307525016, -930251592, -1638685546, 1354460680, 623522045, -1370026032, -307525016, -2084083624, -930251592, 472570145, -1370026032, 1063150409, 160988123, 1122167217, 1145305475, 472570145, 623522045, 1122167217, 1354460680, 1145305475 };
            answer = new int[] { 160988123, 1063150409 };
            result = solution.SingleNumber(nums); Array.Sort(result);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");
        }
    }
}
