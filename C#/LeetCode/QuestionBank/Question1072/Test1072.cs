using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1072
{
    public class Test1072
    {
        public void Test()
        {
            Interface1072 solution = new Solution1072();
            int[][] matrix;
            int result, answer;
            int id = 0;

            // 1. 
            matrix = new int[][] { new int[] { 0, 1 }, new int[] { 1, 1 } };
            answer = 1;
            result = solution.MaxEqualRowsAfterFlips(matrix);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            matrix = new int[][] { new int[] { 0, 1 }, new int[] { 1, 0 } };
            answer = 2;
            result = solution.MaxEqualRowsAfterFlips(matrix);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            matrix = new int[][] { new int[] { 0, 0, 0 }, new int[] { 0, 0, 1 }, new int[] { 1, 1, 0 } };
            answer = 2;
            result = solution.MaxEqualRowsAfterFlips(matrix);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            matrix = new int[][] {
                new int[] { 1, 0, 0, 0, 1, 1, 1, 0, 1, 1, 1 },
                new int[] { 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0 },
                new int[] { 1, 0, 0, 0, 1, 1, 1, 0, 1, 1, 1 },
                new int[] { 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0 },
                new int[] { 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1 } };
            answer = 2;
            result = solution.MaxEqualRowsAfterFlips(matrix);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            matrix = new int[][] {
                new int[] { 0, 1, 0, 1, 0 },
                new int[] { 0, 1, 1, 1, 0 },
                new int[] { 0, 0, 0, 0, 0 },
                new int[] { 0, 1, 1, 1, 1 },
                new int[] { 1, 1, 0, 0, 0 },
                new int[] { 1, 0, 1, 0, 0 },
                new int[] { 0, 0, 0, 1, 1 },
                new int[] { 1, 1, 1, 0, 0 },
                new int[] { 1, 0, 0, 0, 0 },
                new int[] { 0, 1, 0, 0, 0 },
                new int[] { 1, 0, 1, 1, 0 },
                new int[] { 0, 1, 1, 0, 1 },
                new int[] { 0, 1, 0, 0, 0 },
                new int[] { 1, 1, 0, 0, 1 },
                new int[] { 1, 1, 1, 1, 1 },
                new int[] { 0, 0, 1, 1, 0 },
                new int[] { 1, 1, 1, 0, 0 },
                new int[] { 1, 0, 0, 1, 0 },
                new int[] { 1, 1, 0, 1, 0 },
                new int[] { 1, 1, 0, 0, 1 },
                new int[] { 1, 0, 0, 1, 0 },
                new int[] { 0, 0, 0, 0, 0 },
                new int[] { 1, 1, 0, 1, 1 },
                new int[] { 1, 1, 1, 1, 0 },
                new int[] { 0, 0, 0, 0, 1 },
                new int[] { 0, 0, 0, 1, 1 },
                new int[] { 0, 0, 1, 0, 0 },
                new int[] { 1, 1, 0, 1, 1 },
                new int[] { 0, 1, 1, 0, 1 },
                new int[] { 1, 1, 0, 1, 0 } };
            answer = 4;
            result = solution.MaxEqualRowsAfterFlips(matrix);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
