using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3446
{
    public class Test3446
    {
        public void Test()
        {
            Interface3446 solution = new Solution3446_2();
            int[][] grid;
            int[][] result, answer;
            int id = 0;

            // 1. 
            grid = [[1, 7, 3], [9, 8, 2], [4, 5, 6]];
            answer = [[8, 2, 3], [9, 6, 7], [4, 5, 1]];
            result = solution.SortMatrix(grid);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result, false)}, answer: {Utils.ToString(answer, false)}");

            // 2. 
            grid = [[0, 1], [1, 2]];
            answer = [[2, 1], [1, 0]];
            result = solution.SortMatrix(grid);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result, false)}, answer: {Utils.ToString(answer, false)}");

            // 3. 
            grid = [[1]];
            answer = [[1]];
            result = solution.SortMatrix(grid);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result, false)}, answer: {Utils.ToString(answer, false)}");
        }
    }
}
