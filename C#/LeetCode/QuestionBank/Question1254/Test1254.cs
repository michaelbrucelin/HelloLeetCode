using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1254
{
    public class Test1254
    {
        public void Test()
        {
            Interface1254 solution = new Solution1254_2();
            int[][] grid;
            int result, answer;
            int id = 0;

            // 1. 
            grid = new int[][] { new int[] { 1, 1, 1, 1, 1, 1, 1, 0 },
                                 new int[] { 1, 0, 0, 0, 0, 1, 1, 0 },
                                 new int[] { 1, 0, 1, 0, 1, 1, 1, 0 },
                                 new int[] { 1, 0, 0, 0, 0, 1, 0, 1 },
                                 new int[] { 1, 1, 1, 1, 1, 1, 1, 0 } };
            answer = 2;
            result = solution.ClosedIsland(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            grid = new int[][] { new int[] { 0, 0, 1, 0, 0 }, new int[] { 0, 1, 0, 1, 0 }, new int[] { 0, 1, 1, 1, 0 } };
            answer = 1;
            result = solution.ClosedIsland(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            grid = new int[][]{ new int[] { 1, 1, 1, 1, 1, 1, 1 },
                                new int[] { 1, 0, 0, 0, 0, 0, 1 },
                                new int[] { 1, 0, 1, 1, 1, 0, 1 },
                                new int[] { 1, 0, 1, 0, 1, 0, 1 },
                                new int[] { 1, 0, 1, 1, 1, 0, 1 },
                                new int[] { 1, 0, 0, 0, 0, 0, 1 },
                                new int[] { 1, 1, 1, 1, 1, 1, 1 } };
            answer = 2;
            result = solution.ClosedIsland(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
