using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1574
{
    public class Test1574
    {
        public void Test()
        {
            Interface1574 solution = new Solution1574();
            int[] arr;
            int result, answer;
            int id = 0;

            // 1. 
            arr = new int[] { 1, 2, 3, 10, 4, 2, 3, 5 }; answer = 3;
            result = solution.FindLengthOfShortestSubarray(arr);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            arr = new int[] { 5, 4, 3, 2, 1 }; answer = 4;
            result = solution.FindLengthOfShortestSubarray(arr);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            arr = new int[] { 1, 2, 3 }; answer = 0;
            result = solution.FindLengthOfShortestSubarray(arr);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            arr = new int[] { 1 }; answer = 0;
            result = solution.FindLengthOfShortestSubarray(arr);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            arr = new int[] { 1, 3, 2, 4 }; answer = 1;
            result = solution.FindLengthOfShortestSubarray(arr);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
