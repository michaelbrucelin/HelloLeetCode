using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1187
{
    public class Test1187
    {
        public void Test()
        {
            Interface1187 solution = new Solution1187();
            int[] arr1, arr2;
            int result, answer;
            int id = 0;

            // 1. 
            arr1 = new int[] { 1, 5, 3, 6, 7 }; arr2 = new int[] { 1, 3, 2, 4 };
            answer = 1;
            result = solution.MakeArrayIncreasing(arr1, arr2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            arr1 = new int[] { 1, 5, 3, 6, 7 }; arr2 = new int[] { 4, 3, 1 };
            answer = 2;
            result = solution.MakeArrayIncreasing(arr1, arr2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            arr1 = new int[] { 1, 5, 3, 6, 7 }; arr2 = new int[] { 1, 6, 3, 3 };
            answer = -1;
            result = solution.MakeArrayIncreasing(arr1, arr2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
