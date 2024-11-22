using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1287
{
    public class Test1287
    {
        public void Test()
        {
            Interface1287 solution = new Solution1287_2();
            int[] arr;
            int result, answer;
            int id = 0;

            // 1. 
            arr = new int[] { 1, 2, 2, 6, 6, 6, 6, 7, 10 };
            answer = 6;
            result = solution.FindSpecialInteger(arr);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            arr = new int[] { 1, 1 };
            answer = 1;
            result = solution.FindSpecialInteger(arr);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            arr = new int[] { 1 };
            answer = 1;
            result = solution.FindSpecialInteger(arr);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
