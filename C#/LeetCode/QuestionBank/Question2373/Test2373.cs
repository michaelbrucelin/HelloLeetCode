using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2373
{
    public class Test2373
    {
        public void Test()
        {
            Interface2373 solution = new Solution2373_3();
            int[][] grid;
            int[][] result, answer;
            int id = 0;

            // 1. 
            grid = new int[][] { new int[] { 9, 9, 8, 1 }, new int[] { 5, 6, 2, 6 }, new int[] { 8, 2, 6, 4 }, new int[] { 6, 2, 2, 2 } };
            answer = new int[][] { new int[] { 9, 9 }, new int[] { 8, 6 } };
            result = solution.LargestLocal(grid);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer, false) + ",",-6} result: {Utils.ToString(result, false)}, answer: {Utils.ToString(answer, false)}");

            // 2. 
            grid = new int[][] { new int[] { 1, 1, 1, 1, 1 }, new int[] { 1, 1, 1, 1, 1 }, new int[] { 1, 1, 2, 1, 1 }, new int[] { 1, 1, 1, 1, 1 }, new int[] { 1, 1, 1, 1, 1 } };
            answer = new int[][] { new int[] { 2, 2, 2 }, new int[] { 2, 2, 2 }, new int[] { 2, 2, 2 } };
            result = solution.LargestLocal(grid);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer, false) + ",",-6} result: {Utils.ToString(result, false)}, answer: {Utils.ToString(answer, false)}");

            // 3. 
            grid = new int[][] { new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, new int[] { 7, 8, 9 } };
            answer = new int[][] { new int[] { 9 } };
            result = solution.LargestLocal(grid);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer, false) + ",",-6} result: {Utils.ToString(result, false)}, answer: {Utils.ToString(answer, false)}");

            // 4. 
            grid = new int[][] { new int[] { 20,  8, 20,  6, 16, 16,  7, 16,  8, 10 },
                                 new int[] { 12, 15, 13, 10, 20,  9,  6, 18, 17,  6 },
                                 new int[] { 12,  4, 10, 13, 20, 11, 15,  5, 17,  1 },
                                 new int[] {  7, 10, 14, 14, 16,  5,  1,  7,  3, 11 },
                                 new int[] { 16,  2,  9, 15,  9,  8,  6,  1,  7, 15 },
                                 new int[] { 18, 15, 18,  8, 12, 17, 19,  7,  7,  8 },
                                 new int[] { 19, 11, 15, 16,  1,  3,  7,  4,  7, 11 },
                                 new int[] { 11,  6,  5, 14, 12, 18,  3, 20, 14,  6 },
                                 new int[] {  4,  4, 19,  6, 17, 12,  8,  8, 18,  8 },
                                 new int[] { 19, 15, 14, 11, 11, 13, 12,  6, 16, 19 } };
            answer = new int[][] { new int[] { 20, 20, 20, 20, 20, 18, 18, 18 },
                                   new int[] { 15, 15, 20, 20, 20, 18, 18, 18 },
                                   new int[] { 16, 15, 20, 20, 20, 15, 17, 17 },
                                   new int[] { 18, 18, 18, 17, 19, 19, 19, 15 },
                                   new int[] { 19, 18, 18, 17, 19, 19, 19, 15 },
                                   new int[] { 19, 18, 18, 18, 19, 20, 20, 20 },
                                   new int[] { 19, 19, 19, 18, 18, 20, 20, 20 },
                                   new int[] { 19, 19, 19, 18, 18, 20, 20, 20 } };
            result = solution.LargestLocal(grid);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer, false) + ",",-6} result: {Utils.ToString(result, false)}, answer: {Utils.ToString(answer, false)}");
        }
    }
}
