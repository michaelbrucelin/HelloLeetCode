using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1878
{
    public class Test1878
    {
        public void Test()
        {
            Interface1878 solution = new Solution1878_2();
            int[][] grid;
            int[] result, answer;
            int id = 0;

            // 1. 
            grid = [[3, 4, 5, 1, 3], [3, 3, 4, 2, 3], [20, 30, 200, 40, 10], [1, 5, 5, 4, 1], [4, 3, 2, 2, 5]];
            answer = [228, 216, 211];
            result = solution.GetBiggestThree(grid);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            grid = [[1, 2, 3], [4, 5, 6], [7, 8, 9]];
            answer = [20, 9, 8];
            result = solution.GetBiggestThree(grid);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            grid = [[7, 7, 7]];
            answer = [7];
            result = solution.GetBiggestThree(grid);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}
