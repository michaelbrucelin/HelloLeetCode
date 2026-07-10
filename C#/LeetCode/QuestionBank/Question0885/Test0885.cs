using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0885
{
    public class Test0885
    {
        public void Test()
        {
            Interface0885 solution = new Solution0885();
            int rows, cols, rStart, cStart;
            int[][] result, answer;
            int id = 0;

            // 1. 
            rows = 1; cols = 4; rStart = 0; cStart = 0;
            answer = [[0, 0], [0, 1], [0, 2], [0, 3]];
            result = solution.SpiralMatrixIII(rows, cols, rStart, cStart);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result, false)}, answer: {Utils.ToString(answer, false)}");

            // 2. 
            rows = 5; cols = 6; rStart = 1; cStart = 4;
            answer = [[1, 4], [1, 5], [2, 5], [2, 4], [2, 3], [1, 3], [0, 3], [0, 4], [0, 5], [3, 5], [3, 4], [3, 3], [3, 2], [2, 2], [1, 2],
                      [0, 2], [4, 5], [4, 4], [4, 3], [4, 2], [4, 1], [3, 1], [2, 1], [1, 1], [0, 1], [4, 0], [3, 0], [2, 0], [1, 0], [0, 0]];
            result = solution.SpiralMatrixIII(rows, cols, rStart, cStart);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result, false)}, answer: {Utils.ToString(answer, false)}");
        }
    }
}
