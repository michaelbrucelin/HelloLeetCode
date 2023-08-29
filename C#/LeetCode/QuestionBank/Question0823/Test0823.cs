using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0823
{
    public class Test0823
    {
        public void Test()
        {
            Interface0823 solution = new Solution0823();
            int[] arr;
            int result, answer;
            int id = 0;

            // 1. 
            arr = new int[] { 2, 4 };
            answer = 3;
            result = solution.NumFactoredBinaryTrees(arr);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            arr = new int[] { 2, 4, 5, 10 };
            answer = 7;
            result = solution.NumFactoredBinaryTrees(arr);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            arr = new int[] { 18, 3, 6, 2 };
            answer = 12;
            result = solution.NumFactoredBinaryTrees(arr);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            arr = new int[] { 2, 4, 8, 16 };
            answer = 23;
            result = solution.NumFactoredBinaryTrees(arr);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
