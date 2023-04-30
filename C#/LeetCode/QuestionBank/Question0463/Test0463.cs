using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0463
{
    public class Test0463
    {
        public void Test()
        {
            Interface0463 solution = new Solution0463_3();
            int[][] grid;
            int result, answer;
            int id = 0;

            // 1. 
            grid = new int[][] { new int[] { 0, 1, 0, 0 }, new int[] { 1, 1, 1, 0 }, new int[] { 0, 1, 0, 0 }, new int[] { 1, 1, 0, 0 } };
            answer = 16;
            result = solution.IslandPerimeter(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            grid = new int[][] { new int[] { 1 } };
            answer = 4;
            result = solution.IslandPerimeter(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            grid = new int[][] { new int[] { 1, 0 } };
            answer = 4;
            result = solution.IslandPerimeter(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
