using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1329
{
    public class Test1329
    {
        public void Test()
        {
            Interface1329 solution = new Solution1329_err();
            int[][] mat;
            int[][] result, answer;
            int id = 0;

            // 1. 
            mat = [[3, 3, 1, 1], [2, 2, 1, 2], [1, 1, 1, 2]];
            answer = [[1, 1, 1, 1], [1, 2, 2, 2], [1, 2, 3, 3]];
            result = solution.DiagonalSort(mat);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString<int>(result, true)}, answer: {Utils.ToString<int>(answer, true)}");

            // 2. 
            mat = [[11, 25, 66, 1, 69, 7], [23, 55, 17, 45, 15, 52], [75, 31, 36, 44, 58, 8], [22, 27, 33, 25, 68, 4], [84, 28, 14, 11, 5, 50]];
            answer = [[5, 17, 4, 1, 52, 7], [11, 11, 25, 45, 8, 69], [14, 23, 25, 44, 58, 15], [22, 27, 31, 36, 50, 66], [84, 28, 75, 33, 55, 68]];
            result = solution.DiagonalSort(mat);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString<int>(result, true)}, answer: {Utils.ToString<int>(answer, true)}");
        }
    }
}
