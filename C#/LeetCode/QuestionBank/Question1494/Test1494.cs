using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1494
{
    public class Test1494
    {
        public void Test()
        {
            Interface1494 solution = new Solution1494();
            int n; int[][] relations; int k;
            int result, answer;
            int id = 0;

            // 1. 
            n = 4; relations = new int[][] { new int[] { 2, 1 }, new int[] { 3, 1 }, new int[] { 1, 4 } }; k = 2;
            answer = 3;
            result = solution.MinNumberOfSemesters(n, relations, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            n = 5; relations = new int[][] { new int[] { 2, 1 }, new int[] { 3, 1 }, new int[] { 4, 1 }, new int[] { 1, 5 } }; k = 2;
            answer = 4;
            result = solution.MinNumberOfSemesters(n, relations, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            n = 11; relations = new int[][] { }; k = 2;
            answer = 6;
            result = solution.MinNumberOfSemesters(n, relations, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            n = 10; relations = new int[][] { new int[] { 1, 4 }, new int[] { 2, 4 }, new int[] { 3, 4 }, new int[] { 4, 5 },
                                              new int[] { 6, 9 }, new int[] { 7, 9 }, new int[] { 8, 9 }, new int[] { 9, 10 }};
            k = 2; answer = 5;
            result = solution.MinNumberOfSemesters(n, relations, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
