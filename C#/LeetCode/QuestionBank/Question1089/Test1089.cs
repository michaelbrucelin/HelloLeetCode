using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1089
{
    public class Test1089
    {
        public void Test()
        {
            Interface1089 solution = new Solution1089();
            int[] arr;
            int[] result, answer;
            int id = 0;

            // 1. 
            arr = new int[] { 1, 0, 2, 3, 0, 4, 5, 0 };
            answer = new int[] { 1, 0, 0, 2, 3, 0, 0, 4 };
            solution.DuplicateZeros(arr); result = arr;
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            arr = new int[] { 1, 2, 3 };
            answer = new int[] { 1, 2, 3 };
            solution.DuplicateZeros(arr); result = arr;
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            arr = new int[] { 1, 0, 0, 2, 3 };
            answer = new int[] { 1, 0, 0, 0, 0 };
            solution.DuplicateZeros(arr); result = arr;
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 4. 
            arr = new int[] { 0, 0, 0, 0, 0, 0, 0 };
            answer = new int[] { 0, 0, 0, 0, 0, 0, 0 };
            solution.DuplicateZeros(arr); result = arr;
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}
