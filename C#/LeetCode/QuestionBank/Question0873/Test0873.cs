using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0873
{
    public class Test0873
    {
        public void Test()
        {
            Interface0873 solution = new Solution0873();
            int[] arr;
            int result, answer;
            int id = 0;

            // 1. 
            arr = [1, 2, 3, 4, 5, 6, 7, 8];
            answer = 5;
            result = solution.LenLongestFibSubseq(arr);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            arr = [1, 3, 7, 11, 12, 14, 18];
            answer = 3;
            result = solution.LenLongestFibSubseq(arr);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            arr = [2, 5, 6, 7, 8, 10, 12, 17, 24, 41, 65];
            answer = 5;
            result = solution.LenLongestFibSubseq(arr);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            arr = [1, 10, 100];
            answer = 0;
            result = solution.LenLongestFibSubseq(arr);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
