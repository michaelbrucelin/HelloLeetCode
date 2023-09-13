using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1566
{
    public class Test1566
    {
        public void Test()
        {
            Interface1566 solution = new Solution1566_2();
            int[] arr; int m, k;
            bool result, answer;
            int id = 0;

            // 1. 
            arr = Utils.Str2NumArray<int>("[1,2,4,4,4,4]"); m = 1; k = 3;
            answer = true;
            result = solution.ContainsPattern(arr, m, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            arr = Utils.Str2NumArray<int>("[1,2,1,2,1,1,1,3]"); m = 2; k = 2;
            answer = true;
            result = solution.ContainsPattern(arr, m, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            arr = Utils.Str2NumArray<int>("[1,2,1,2,1,3]"); m = 2; k = 3;
            answer = false;
            result = solution.ContainsPattern(arr, m, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            arr = Utils.Str2NumArray<int>("[1,2,3,1,2]"); m = 2; k = 2;
            answer = false;
            result = solution.ContainsPattern(arr, m, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            arr = Utils.Str2NumArray<int>("[2,2,2,2]"); m = 2; k = 3;
            answer = false;
            result = solution.ContainsPattern(arr, m, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
