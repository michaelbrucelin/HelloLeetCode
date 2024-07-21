using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1186
{
    public class Test1186
    {
        public void Test()
        {
            Interface1186 solution = new Solution1186_2();
            int[] arr;
            int result, answer;
            int id = 0;

            // 1. 
            arr = [1, -2, 0, 3];
            answer = 4;
            result = solution.MaximumSum(arr);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            arr = [1, -2, -2, 3];
            answer = 3;
            result = solution.MaximumSum(arr);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            arr = [-1, -1, -1, -1];
            answer = -1;
            result = solution.MaximumSum(arr);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            arr = [-50];
            answer = -50;
            result = solution.MaximumSum(arr);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            arr = [8, -1, 6, -7, -4, 5, -4, 7, -6];
            answer = 17;
            result = solution.MaximumSum(arr);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 6. 
            arr = [1, -2, 0, 5, -1, 2, 1, -3, 2];
            answer = 9;
            result = solution.MaximumSum(arr);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
