using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2617
{
    public class Test2617
    {
        public void Test()
        {
            Interface2617 solution = new Solution2617_3();
            int[][] grid;
            int result, answer;
            int id = 0;

            // 1. 
            grid = Utils.Str2NumArray_2d<int>("[[3,4,2,1],[4,2,3,1],[2,1,0,0],[2,4,0,0]]");
            answer = 4;
            result = solution.MinimumVisitedCells(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            grid = Utils.Str2NumArray_2d<int>("[[3,4,2,1],[4,2,1,1],[2,1,1,0],[3,4,1,0]]");
            answer = 3;
            result = solution.MinimumVisitedCells(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            grid = Utils.Str2NumArray_2d<int>("[[2,1,0],[1,0,0]]");
            answer = -1;
            result = solution.MinimumVisitedCells(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            grid = Utils.Str2NumArray_2d<int>("[[0]]");
            answer = 1;
            result = solution.MinimumVisitedCells(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            string question = "2617", testcase = "05";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            grid = Utils.Str2NumArray_2d<int>(File.ReadAllText($"{path}_{testcase}_grid.txt"));
            answer = 89;
            result = solution.MinimumVisitedCells(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 6. 
            testcase = "06";
            grid = Utils.Str2NumArray_2d<int>(File.ReadAllText($"{path}_{testcase}_grid.txt"));
            answer = -1;
            result = solution.MinimumVisitedCells(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
