using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1252
{
    public class Test1252
    {
        public void Test()
        {
            Interface1252 solution = new Solution1252_5();
            int m, n; int[][] indices;
            int result, answer;
            int id = 0;

            // 1. 
            m = 2; n = 3; indices = new int[][] { new int[] { 0, 1 }, new int[] { 1, 1 } };
            answer = 6;
            result = solution.OddCells(m, n, indices);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            m = 2; n = 2; indices = new int[][] { new int[] { 1, 1 }, new int[] { 0, 0 } };
            answer = 0;
            result = solution.OddCells(m, n, indices);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
