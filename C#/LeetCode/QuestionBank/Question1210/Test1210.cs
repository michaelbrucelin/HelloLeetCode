using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1210
{
    public class Test1210
    {
        public void Test()
        {
            Interface1210 solution = new Solution1210_2();
            int[][] grid;
            int result, answer;
            int id = 0;

            // 1. 
            grid = new int[][] { new int[] {0, 0, 0, 0, 0, 1 },
                                 new int[] {1, 1, 0, 0, 1, 0 },
                                 new int[] {0, 0, 0, 0, 1, 1 },
                                 new int[] {0, 0, 1, 0, 1, 0 },
                                 new int[] {0, 1, 1, 0, 0, 0 },
                                 new int[] {0, 1, 1, 0, 0, 0 } };
            answer = 11;
            result = solution.MinimumMoves(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            grid = new int[][] {new int[] { 0, 0, 1, 1, 1, 1 },
                                new int[] { 0, 0, 0, 0, 1, 1 },
                                new int[] { 1, 1, 0, 0, 0, 1 },
                                new int[] { 1, 1, 1, 0, 0, 1 },
                                new int[] { 1, 1, 1, 0, 0, 1 },
                                new int[] { 1, 1, 1, 0, 0, 0 } };
            answer = 9;
            result = solution.MinimumMoves(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3.
            // [[0,0,0,0,0,0,0,0,0,1],[0,1,0,0,0,0,0,1,0,1],[1,0,0,1,0,0,1,0,1,0],[0,0,0,1,0,1,0,1,0,0],[0,0,0,0,1,0,0,0,0,1],[0,0,1,0,0,0,0,0,0,0],[1,0,0,1,0,0,0,0,0,0],[0,0,0,0,0,0,0,0,0,0],[0,0,0,0,0,0,0,0,0,0],[1,1,0,0,0,0,0,0,0,0]]
            grid = new int[][] { new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                                 new int[] { 0, 1, 0, 0, 0, 0, 0, 1, 0, 1 },
                                 new int[] { 1, 0, 0, 1, 0, 0, 1, 0, 1, 0 },
                                 new int[] { 0, 0, 0, 1, 0, 1, 0, 1, 0, 0 },
                                 new int[] { 0, 0, 0, 0, 1, 0, 0, 0, 0, 1 },
                                 new int[] { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 },
                                 new int[] { 1, 0, 0, 1, 0, 0, 0, 0, 0, 0 },
                                 new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                 new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                 new int[] { 1, 1, 0, 0, 0, 0, 0, 0, 0, 0 } };
            answer = -1;
            result = solution.MinimumMoves(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            // [[0,0,0,0,0,0,0,1,0,0,1,0,0,0,0],[1,0,0,0,0,1,0,0,0,0,0,0,1,0,0],[1,0,0,0,0,0,0,0,0,0,0,0,0,0,1],[0,0,1,0,1,0,0,0,0,1,0,0,1,0,0],[0,0,0,0,0,0,0,1,0,0,0,0,0,1,0],[1,0,0,0,1,0,0,0,0,0,0,0,1,0,1],[1,0,0,0,0,0,0,0,0,0,0,1,0,1,0],[0,0,0,0,0,0,0,0,0,0,0,0,1,0,0],[1,0,0,0,0,0,1,0,0,0,0,0,1,1,0],[0,0,0,0,0,0,0,0,0,0,0,0,1,1,0],[0,1,0,0,1,0,1,0,0,0,1,0,1,1,0],[0,1,0,1,1,0,0,0,0,0,1,0,0,0,0],[0,0,0,0,0,0,0,0,0,0,0,0,0,0,0],[0,0,0,0,1,1,1,0,0,0,1,0,1,0,0],[0,0,0,0,0,1,0,0,1,0,0,1,0,0,0]]
            grid = new int[][] { new int[]{ 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0 },
                                 new int[] { 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0 },
                                 new int[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                                 new int[] { 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0 },
                                 new int[] { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0 },
                                 new int[] { 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1 },
                                 new int[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0 },
                                 new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 },
                                 new int[] { 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 1, 0 },
                                 new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0 },
                                 new int[] { 0, 1, 0, 0, 1, 0, 1, 0, 0, 0, 1, 0, 1, 1, 0 },
                                 new int[] { 0, 1, 0, 1, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 },
                                 new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                 new int[] { 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 1, 0, 1, 0, 0 },
                                 new int[] { 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 0 } };
            answer = 27;
            result = solution.MinimumMoves(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
