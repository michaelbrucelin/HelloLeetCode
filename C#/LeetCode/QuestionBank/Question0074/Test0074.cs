using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0074
{
    public class Test0074
    {
        public void Test()
        {
            Interface0074 solution = new Solution0074_5();
            int[][] matrix; int target;
            bool result, answer;
            int id = 0;

            // 1. 
            matrix = new int[][] { new int[] { 1, 3, 5, 7 }, new int[] { 10, 11, 16, 20 }, new int[] { 23, 30, 34, 60 } };
            target = 3; answer = true;
            result = solution.SearchMatrix(matrix, target);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            matrix = new int[][] { new int[] { 1, 3, 5, 7 }, new int[] { 10, 11, 16, 20 }, new int[] { 23, 30, 34, 60 } };
            target = 13; answer = false;
            result = solution.SearchMatrix(matrix, target);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            matrix = new int[][] { new int[] { 1 } };
            target = 2; answer = false;
            result = solution.SearchMatrix(matrix, target);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
