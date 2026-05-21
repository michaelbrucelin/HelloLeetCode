using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3043
{
    public class Test3043
    {
        public void Test()
        {
            Interface3043 solution = new Solution3043();
            int[] arr1, arr2;
            int result, answer;
            int id = 0;

            // 1. 
            arr1 = [1, 10, 100]; arr2 = [1000];
            answer = 3;
            result = solution.LongestCommonPrefix(arr1, arr2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            arr1 = [1, 2, 3]; arr2 = [4, 4, 4];
            answer = 0;
            result = solution.LongestCommonPrefix(arr1, arr2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            arr1 = [39, 1, 47, 12, 24]; arr2 = [19, 5, 16, 23, 22];
            answer = 1;
            result = solution.LongestCommonPrefix(arr1, arr2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
