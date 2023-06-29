using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1013
{
    public class Test1013
    {
        public void Test()
        {
            Interface1013 solution = new Solution1013();
            int[] arr;
            bool result, answer;
            int id = 0;

            // 1. 
            arr = new int[] { 0, 2, 1, -6, 6, -7, 9, 1, 2, 0, 1 };
            answer = true;
            result = solution.CanThreePartsEqualSum(arr);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            arr = new int[] { 0, 2, 1, -6, 6, 7, 9, -1, 2, 0, 1 };
            answer = false;
            result = solution.CanThreePartsEqualSum(arr);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            arr = new int[] { 3, 3, 6, 5, -2, 2, 5, 1, -9, 4 };
            answer = true;
            result = solution.CanThreePartsEqualSum(arr);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            arr = new int[] { 1, -1, 1, -1 };
            answer = false;
            result = solution.CanThreePartsEqualSum(arr);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
