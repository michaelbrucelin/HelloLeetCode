using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0883
{
    public class Test0883
    {
        public void Test()
        {
            Interface0883 solution = new Solution0883();
            int[][] grid;
            int result, answer;
            int id = 0;

            // 1. 
            grid = new int[][] { new int[] { 1, 2 }, new int[] { 3, 4 } }; answer = 17;
            result = solution.ProjectionArea(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            grid = new int[][] { new int[] { 2 } }; answer = 5;
            result = solution.ProjectionArea(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            grid = new int[][] { new int[] { 1, 0 }, new int[] { 0, 2 } }; answer = 8;
            result = solution.ProjectionArea(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            grid = new int[][] { new int[] { 1, 4 }, new int[] { 1, 1 } }; answer = 14;
            result = solution.ProjectionArea(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
