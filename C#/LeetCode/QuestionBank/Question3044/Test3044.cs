using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3044
{
    public class Test3044
    {
        public void Test()
        {
            Interface3044 solution = new Solution3044();
            int[][] mat;
            int result, answer;
            int id = 0;

            // 1. 
            mat = [[1, 1], [9, 9], [1, 1]];
            answer = 19;
            result = solution.MostFrequentPrime(mat);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            mat = [[7]];
            answer = -1;
            result = solution.MostFrequentPrime(mat);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            mat = [[9, 7, 8], [4, 6, 5], [2, 8, 6]];
            answer = 97;
            result = solution.MostFrequentPrime(mat);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            mat = [[8, 9, 3], [3, 5, 6], [1, 2, 5]];
            answer = 53;
            result = solution.MostFrequentPrime(mat);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
