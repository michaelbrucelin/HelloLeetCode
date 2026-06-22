using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1034
{
    public class Test1034
    {
        public void Test()
        {
            Interface1034 solution = new Solution1034();
            int[][] grid; int row, col, color;
            int[][] result, answer;
            int id = 0;

            // 1. 
            grid = [[1, 1], [1, 2]]; row = 0; col = 0; color = 3;
            answer = [[3, 3], [3, 2]];
            result = solution.ColorBorder(grid, row, col, color);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result, false)}, answer: {Utils.ToString(answer, false)}");

            // 2. 
            grid = [[1, 2, 2], [2, 3, 2]]; row = 0; col = 1; color = 3;
            answer = [[1, 3, 3], [2, 3, 3]];
            result = solution.ColorBorder(grid, row, col, color);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result, false)}, answer: {Utils.ToString(answer, false)}");

            // 3. 
            grid = [[1, 1, 1], [1, 1, 1], [1, 1, 1]]; row = 1; col = 1; color = 2;
            answer = [[2, 2, 2], [2, 1, 2], [2, 2, 2]];
            result = solution.ColorBorder(grid, row, col, color);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result, false)}, answer: {Utils.ToString(answer, false)}");

            // 4. 
            grid = [[1, 2, 1, 2, 1, 2], [2, 2, 2, 2, 1, 2], [1, 2, 2, 2, 1, 2]]; row = 1; col = 3; color = 1;
            answer = [[1, 1, 1, 1, 1, 2], [1, 2, 1, 1, 1, 2], [1, 1, 1, 1, 1, 2]];
            result = solution.ColorBorder(grid, row, col, color);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result, false)}, answer: {Utils.ToString(answer, false)}");
        }
    }
}
