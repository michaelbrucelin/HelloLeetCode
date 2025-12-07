using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1162
{
    public class Test1162
    {
        public void Test()
        {
            Interface1162 solution = new Solution1162_3();
            int[][] grid;
            int result, answer;
            int id = 0;

            // 1. 
            grid = [];
            answer = -1;
            result = solution.MaxDistance(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            grid = [[1, 0, 1], [0, 0, 0], [1, 0, 1]];
            answer = 2;
            result = solution.MaxDistance(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            grid = [[1, 0, 0], [0, 0, 0], [0, 0, 0]];
            answer = 4;
            result = solution.MaxDistance(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            grid = [[0, 0, 0], [0, 0, 0], [0, 0, 0]];
            answer = -1;
            result = solution.MaxDistance(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            grid = [[1, 1, 1], [1, 1, 1], [1, 1, 1]];
            answer = -1;
            result = solution.MaxDistance(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 6. 
            string question = "1162", testcase = "06", arg = "grid";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            grid = Utils.Str2NumArray_2d<int>(File.ReadAllText($"{path}_{testcase}_{arg}.txt"));
            answer = 198;
            result = solution.MaxDistance(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
