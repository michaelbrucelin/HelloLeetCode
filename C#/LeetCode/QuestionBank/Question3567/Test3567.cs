using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3567
{
    public class Test3567
    {
        public void Test()
        {
            Interface3567 solution = new Solution3567_2();
            int[][] grid; int k;
            int[][] result, answer;
            int id = 0;

            // 1. 
            grid = [[1, 8], [3, -2]]; k = 2;
            answer = [[2]];
            result = solution.MinAbsDiff(grid, k);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result, false)}, answer: {Utils.ToString(answer, false)}");

            // 2. 
            grid = [[3, -1]]; k = 1;
            answer = [[0, 0]];
            result = solution.MinAbsDiff(grid, k);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result, false)}, answer: {Utils.ToString(answer, false)}");

            // 3. 
            grid = [[1, -2, 3], [2, 3, 5]]; k = 2;
            answer = [[1, 2]];
            result = solution.MinAbsDiff(grid, k);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result, false)}, answer: {Utils.ToString(answer, false)}");

            // 4. 
            grid = [[41792, 59482], [49179, -22072]]; k = 2;
            answer = [[7387]];
            result = solution.MinAbsDiff(grid, k);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result, false)}, answer: {Utils.ToString(answer, false)}");
        }
    }
}
