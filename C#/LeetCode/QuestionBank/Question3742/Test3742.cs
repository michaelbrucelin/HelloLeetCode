using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3742
{
    public class Test3742
    {
        public void Test()
        {
            Interface3742 solution = new Solution3742_2();
            int[][] grid; int k;
            int result, answer;
            int id = 0;

            // 1. 
            grid = [[0, 1], [2, 0]]; k = 1;
            answer = 2;
            result = solution.MaxPathScore(grid, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            grid = [[0, 1], [1, 2]]; k = 1;
            answer = -1;
            result = solution.MaxPathScore(grid, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            grid = [[0, 0, 0, 1]]; k = 0;
            answer = -1;
            result = solution.MaxPathScore(grid, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            grid = [[0, 1, 1, 1], [1, 2, 2, 0], [1, 0, 1, 2]]; k = 4;
            answer = 7;
            result = solution.MaxPathScore(grid, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            string question = "3742", testcase = "05", arg = "grid";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            grid = Utils.Str2NumArray_2d<int>(File.ReadAllText($"{path}_{testcase}_{arg}.txt"));
            k = 0;
            answer = 0;
            result = solution.MaxPathScore(grid, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 6. 
            testcase = "06";
            grid = Utils.Str2NumArray_2d<int>(File.ReadAllText($"{path}_{testcase}_{arg}.txt"));
            k = 0;
            answer = -1;
            result = solution.MaxPathScore(grid, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
