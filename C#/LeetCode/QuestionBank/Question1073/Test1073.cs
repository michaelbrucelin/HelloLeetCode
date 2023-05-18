using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1073
{
    public class Test1073
    {
        public void Test()
        {
            Interface1073 solution = new Solution1073_2();
            int[] arr1, arr2;
            int[] result, answer;
            int id = 0;

            // 1. 
            arr1 = new int[] { 1, 1, 1, 1, 1 }; arr2 = new int[] { 1, 0, 1 };
            answer = new int[] { 1, 0, 0, 0, 0 };
            result = solution.AddNegabinary(arr1, arr2);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 2. 
            arr1 = new int[] { 0 }; arr2 = new int[] { 0 };
            answer = new int[] { 0 };
            result = solution.AddNegabinary(arr1, arr2);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 3. 
            arr1 = new int[] { 0 }; arr2 = new int[] { 1 };
            answer = new int[] { 1 };
            result = solution.AddNegabinary(arr1, arr2);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 4. 
            arr1 = new int[] { 1 }; arr2 = new int[] { 1, 1 };
            answer = new int[] { 0 };
            result = solution.AddNegabinary(arr1, arr2);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 5. 
            arr1 = new int[] { 1, 1, 1, 1, 1 }; arr2 = new int[] { 1, 1, 1, 1 };
            answer = new int[] { 1, 1, 0, 1, 0 };
            result = solution.AddNegabinary(arr1, arr2);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 6. 
            arr1 = new int[] { 1, 0, 1, 0, 1 }; arr2 = new int[] { 1, 0, 1 };
            answer = new int[] { 1, 1, 0, 1, 1, 1, 0 };
            result = solution.AddNegabinary(arr1, arr2);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");
        }
    }
}
