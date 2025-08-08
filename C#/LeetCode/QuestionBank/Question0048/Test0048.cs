using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0048
{
    public class Test0048
    {
        public void Test()
        {
            Interface0048 solution = new Solution0048_3();
            int[][] matrix;
            int[][] result, answer;
            int id = 0;

            // 1. 
            matrix = [[1, 2, 3], [4, 5, 6], [7, 8, 9]];
            answer = [[7, 4, 1], [8, 5, 2], [9, 6, 3]];
            solution.Rotate(matrix);
            result = matrix;
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString<int>(result, true)}, answer: {Utils.ToString<int>(answer, true)}");

            // 2. 
            matrix = [[5, 1, 9, 11], [2, 4, 8, 10], [13, 3, 6, 7], [15, 14, 12, 16]];
            answer = [[15, 13, 2, 5], [14, 3, 4, 1], [12, 6, 8, 9], [16, 7, 10, 11]];
            solution.Rotate(matrix);
            result = matrix;
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString<int>(result, true)}, answer: {Utils.ToString<int>(answer, true)}");
        }
    }
}
