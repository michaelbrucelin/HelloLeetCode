using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1970
{
    public class Test1970
    {
        public void Test()
        {
            Interface1970 solution = new Solution1970();
            int row, col; int[][] cells;
            int result, answer;
            int id = 0;

            // 1. 
            row = 2; col = 2; cells = [[1, 1], [2, 1], [1, 2], [2, 2]];
            answer = 2;
            result = solution.LatestDayToCross(row, col, cells);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            row = 2; col = 2; cells = [[1, 1], [1, 2], [2, 1], [2, 2]];
            answer = 1;
            result = solution.LatestDayToCross(row, col, cells);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            row = 3; col = 3; cells = [[1, 2], [2, 1], [3, 3], [2, 2], [1, 1], [1, 3], [2, 3], [3, 2], [3, 1]];
            answer = 3;
            result = solution.LatestDayToCross(row, col, cells);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            row = 13; col = 9;
            cells = [[12, 6], [3, 4], [2, 9], [9, 4], [9, 2], [6, 4], [4, 4], [8, 6], [4, 9], [5, 6], [7, 5], [12, 4], [11, 8], [3, 7], [2, 6], [9, 8], [3, 5], [13, 4], [1, 3], [10, 2], [8, 9],
                     [6, 6], [11, 7], [11, 1], [13, 9], [12, 7], [10, 7], [8, 2], [1, 8], [7, 3], [6, 5], [2, 1], [10, 6], [4, 8], [4, 2], [9, 7], [6, 2], [3, 6], [12, 2], [10, 3], [10, 5],
                     [9, 5], [8, 8], [8, 7], [3, 2], [13, 6], [3, 1], [5, 1], [2, 7], [8, 3], [12, 5], [11, 2], [6, 3], [1, 4], [13, 3], [4, 1], [9, 9], [7, 7], [4, 3], [12, 1], [2, 2], [7, 6],
                     [4, 6], [7, 9], [7, 2], [3, 8], [1, 6], [11, 3], [11, 4], [5, 9], [13, 8], [1, 9], [10, 1], [9, 1], [6, 1], [10, 9], [12, 9], [11, 5], [8, 1], [13, 5], [9, 6], [13, 2],
                     [6, 8], [2, 8], [5, 3], [3, 3], [13, 1], [11, 9], [9, 3], [2, 4], [5, 2], [8, 5], [13, 7], [12, 8], [5, 5], [7, 1], [7, 4], [2, 5], [6, 9], [4, 7], [5, 8], [1, 5], [10, 8],
                     [8, 4], [1, 1], [3, 9], [1, 2], [7, 8], [1, 7], [6, 7], [11, 6], [4, 5], [5, 7], [2, 3], [10, 4], [5, 4], [12, 3]];
            answer = 35;
            result = solution.LatestDayToCross(row, col, cells);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
