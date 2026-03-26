using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3548
{
    public class Test3548
    {
        public void Test()
        {
            Interface3548 solution = new Solution3548();
            int[][] grid;
            bool result, answer;
            int id = 0;

            // 1. 
            grid = [[1, 4], [2, 3]];
            answer = true;
            result = solution.CanPartitionGrid(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            grid = [[1, 2], [3, 4]];
            answer = true;
            result = solution.CanPartitionGrid(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            grid = [[1, 2, 4], [2, 3, 5]];
            answer = false;
            result = solution.CanPartitionGrid(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            grid = [[4, 1, 8], [3, 2, 6]];
            answer = false;
            result = solution.CanPartitionGrid(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            grid = [[10, 5, 4, 5]];
            answer = false;
            result = solution.CanPartitionGrid(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 6. 
            grid = [[5, 5, 6, 2, 2, 2]];
            answer = true;
            result = solution.CanPartitionGrid(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 7. 
            grid = [[1, 1], [2, 1], [4, 3]];
            answer = false;
            result = solution.CanPartitionGrid(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 8. 
            string question = "3548", testcase = "08", arg = "grid";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            grid = Utils.Str2NumArray_2d<int>(File.ReadAllText($"{path}_{testcase}_{arg}.txt"));
            answer = false;
            result = solution.CanPartitionGrid(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
