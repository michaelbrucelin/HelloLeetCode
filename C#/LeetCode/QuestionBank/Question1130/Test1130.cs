using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1130
{
    public class Test1130
    {
        public void Test()
        {
            Interface1130 solution = new Solution1130_2();
            int[] arr;
            int result, answer;
            int id = 0;

            // 1. 
            arr = new int[] { 6, 2, 4 }; answer = 32;
            result = solution.MctFromLeafValues(arr);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            arr = new int[] { 4, 11 }; answer = 44;
            result = solution.MctFromLeafValues(arr);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            arr = new int[] { 7, 5, 12, 2, 2, 3, 13, 8, 4, 9, 12, 9, 3, 10, 4, 13, 7, 5, 15 }; answer = 1456;
            result = solution.MctFromLeafValues(arr);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
