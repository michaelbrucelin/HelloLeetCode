using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0167
{
    public class Test0167
    {
        public void Test()
        {
            Interface0167 solution = new Solution0167_2();
            int[] numbers; int target;
            int[] result, answer;
            int id = 0;

            // 1. 
            numbers = UtilsLeetCode.Str2NumArray<int>("[2,7,11,15]"); target = 9;
            answer = new int[] { 1, 2 };
            result = solution.TwoSum(numbers, target);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 2. 
            numbers = UtilsLeetCode.Str2NumArray<int>("[2,3,4]"); target = 6;
            answer = new int[] { 1, 3 };
            result = solution.TwoSum(numbers, target);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 3. 
            numbers = UtilsLeetCode.Str2NumArray<int>("[-1,0]"); target = -1;
            answer = new int[] { 1, 2 };
            result = solution.TwoSum(numbers, target);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 4. 
            numbers = UtilsLeetCode.Str2NumArray<int>("[0,0,3,4]"); target = 0;
            answer = new int[] { 1, 2 };
            result = solution.TwoSum(numbers, target);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 5. 
            numbers = UtilsLeetCode.Str2NumArray<int>("[5,25,75]"); target = 100;
            answer = new int[] { 2, 3 };
            result = solution.TwoSum(numbers, target);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");
        }
    }
}
