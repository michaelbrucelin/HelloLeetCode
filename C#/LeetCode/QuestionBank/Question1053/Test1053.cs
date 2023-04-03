using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1053
{
    public class Test1053
    {
        public void Test()
        {
            Interface1053 solution = new Solution1053_2();
            int[] arr;
            int[] result, answer;
            int id = 0;

            // 1. 
            arr = new int[] { 3, 2, 1 }; answer = new int[] { 3, 1, 2 };
            result = solution.PrevPermOpt1(arr);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 2. 
            arr = new int[] { 1, 1, 5 }; answer = new int[] { 1, 1, 5 };
            result = solution.PrevPermOpt1(arr);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 3. 
            arr = new int[] { 1, 9, 4, 6, 7 }; answer = new int[] { 1, 7, 4, 6, 9 };
            result = solution.PrevPermOpt1(arr);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 4. 
            arr = new int[] { 3, 1, 1, 3 }; answer = new int[] { 1, 3, 1, 3 };
            result = solution.PrevPermOpt1(arr);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 5. 
            arr = new int[] { 1, 9, 4, 4, 6, 7 }; answer = new int[] { 1, 7, 4, 4, 6, 9 };
            result = solution.PrevPermOpt1(arr);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");
        }
    }
}
