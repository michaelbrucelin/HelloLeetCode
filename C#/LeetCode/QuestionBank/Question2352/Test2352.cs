using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2352
{
    public class Test2352
    {
        public void Test()
        {
            Interface2352 solution = new Solution2352_2();
            int[][] grid;
            int result, answer;
            int id = 0;

            // 1. 
            grid = new int[][] { new int[] { 3, 2, 1 }, new int[] { 1, 7, 6 }, new int[] { 2, 7, 7 } };
            answer = 1;
            result = solution.EqualPairs(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            grid = new int[][] { new int[] { 3, 1, 2, 2 }, new int[] { 1, 4, 4, 5 }, new int[] { 2, 4, 2, 2 }, new int[] { 2, 4, 2, 2 } };
            answer = 3;
            result = solution.EqualPairs(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            //grid = new int[][] { new int[] {  }, new int[] {  }, new int[] {  }, new int[] {  } };
            //answer = ;
            //result = solution.EqualPairs(grid);
            //Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
